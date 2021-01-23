    using System;
    using System.Messaging;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    namespace StackOverflow.Q34437298
    {
        /// <summary>
        /// Pumps the message queue and processes messages in parallel.
        /// </summary>
        public sealed class MessagePump
        {
            /// <summary>
            /// Creates a <see cref="MessagePump"/> and immediately starts pumping.
            /// </summary>
            public static MessagePump Run(
                MessageQueue messageQueue,
                Func<Message, Task> processMessage,
                int maxDegreeOfParallelism,
                CancellationToken ct = default(CancellationToken))
            {
                if (messageQueue == null) throw new ArgumentNullException(nameof(messageQueue));
                if (processMessage == null) throw new ArgumentNullException(nameof(processMessage));
                if (maxDegreeOfParallelism <= 0) throw new ArgumentOutOfRangeException(nameof(maxDegreeOfParallelism));
                ct.ThrowIfCancellationRequested();
                return new MessagePump(messageQueue, processMessage, maxDegreeOfParallelism, ct);
            }
            private readonly TaskCompletionSource<bool> _stop = new TaskCompletionSource<bool>();
            /// <summary>
            /// <see cref="Task"/> which completes when this instance
            /// stops due to a <see cref="Stop"/> or cancellation request.
            /// </summary>
            public Task Completion { get; }
            /// <summary>
            /// Maximum number of parallel message processors.
            /// </summary>
            public int MaxDegreeOfParallelism { get; }
            /// <summary>
            /// <see cref="MessageQueue"/> that is pumped by this instance.
            /// </summary>
            public MessageQueue MessageQueue { get; }
            /// <summary>
            /// Creates a new <see cref="MessagePump"/> instance.
            /// </summary>
            private MessagePump(MessageQueue messageQueue, Func<Message, Task> processMessage, int maxDegreeOfParallelism, CancellationToken ct)
            {
                MessageQueue = messageQueue;
                MaxDegreeOfParallelism = maxDegreeOfParallelism;
                // Kick off the loop.
                Completion = RunAsync(processMessage, ct);
            }
            /// <summary>
            /// Soft-terminates the pump so that no more messages will be pumped.
            /// Any messages already removed from the message queue will be
            /// processed before this instance fully completes.
            /// </summary>
            public void Stop()
            {
                // Multiple calls to Stop are fine.
                _stop.TrySetResult(true);
            }
            /// <summary>
            /// Pump implementation.
            /// </summary>
            private async Task RunAsync(Func<Message, Task> processMessage, CancellationToken ct = default(CancellationToken))
            {
                // Handover between producer and consumer.
                DataflowBlockOptions bufferOptions = new DataflowBlockOptions
                {
                    // There is no point in dequeuing more messages than we can process,
                    // so we'll throttle the producer by limiting the buffer capacity.
                    BoundedCapacity = MaxDegreeOfParallelism,
                    CancellationToken = ct
                };
                BufferBlock<Message> buffer = new BufferBlock<Message>(bufferOptions);
                Task producer = Task.Run(async () =>
                {
                    try
                    {
                        while (_stop.Task.Status != TaskStatus.RanToCompletion)
                        {
                            // This is the *only* two cancellation points which will not cause dropped messages.
                            ct.ThrowIfCancellationRequested();
                            Task<Message> peekTask = WithCancellation(PeekAsync(MessageQueue), ct);
                            if (await Task.WhenAny(peekTask, _stop.Task).ConfigureAwait(false) == _stop.Task)
                            {
                                // Stop was signaled before PeekAsync returned. Wind down the producer gracefully
                                // by breaking out and propagating completion to the consumer blocks.
                                break;
                            }
                            await peekTask.ConfigureAwait(false); // Observe Peek exceptions.
                            // Zero timeout means that we will error if someone else snatches the
                            // peeked message from the queue before we get to it (due to a race).
                            // I deemed this better than getting stuck waiting for a message which
                            // may never arrive, or, worse yet, let this ReceiveAsync run onobserved
                            // due to a cancellation (if we choose to abandon it like we do PeekAsync).
                            // Omit timeout if this behaviour is undesired.
                            Message message = await ReceiveAsync(MessageQueue, timeout: TimeSpan.Zero).ConfigureAwait(false);
                            await buffer.SendAsync(message, ct).ConfigureAwait(false);
                        }
                    }
                    finally
                    {
                        buffer.Complete();
                    }
                },
                ct);
                // Wire up the parallel consumers.
                ExecutionDataflowBlockOptions executionOptions = new ExecutionDataflowBlockOptions {
                    CancellationToken = ct,
                    MaxDegreeOfParallelism = MaxDegreeOfParallelism,
                    SingleProducerConstrained = true // We don't require thread safety guarantees.
                };
                ActionBlock<Message> consumer = new ActionBlock<Message>(async message =>
                {
                    ct.ThrowIfCancellationRequested();
                    await processMessage(message).ConfigureAwait(false);
                },
                executionOptions);
                buffer.LinkTo(consumer, new DataflowLinkOptions { PropagateCompletion = true });
                await Task.WhenAll(producer, consumer.Completion).ConfigureAwait(false);
            }
            /// <summary>
            /// APM -> TAP conversion for MessageQueue.Begin/EndPeek.
            /// </summary>
            private static Task<Message> PeekAsync(MessageQueue messageQueue)
            {
                return Task.Factory.FromAsync(messageQueue.BeginPeek(), messageQueue.EndPeek);
            }
            /// <summary>
            /// APM -> TAP conversion for MessageQueue.Begin/EndReceive.
            /// </summary>
            private static Task<Message> ReceiveAsync(MessageQueue messageQueue, TimeSpan timeout)
            {
                return Task.Factory.FromAsync(messageQueue.BeginReceive(timeout), messageQueue.EndPeek);
            }
            /// <summary>
            /// Allows abandoning tasks which do not natively
            /// support cancellation. Use with caution.
            /// </summary>
            private static async Task<T> WithCancellation<T>(Task<T> task, CancellationToken ct)
            {
                ct.ThrowIfCancellationRequested();
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                using (ct.Register(s => ((TaskCompletionSource<bool>)s).TrySetResult(true), tcs, false))
                {
                    if (task != await Task.WhenAny(task, tcs.Task).ConfigureAwait(false))
                    {
                        // Cancellation task completed first.
                        // We are abandoning the original task.
                        throw new OperationCanceledException(ct);
                    }
                }
                // Task completed: synchronously return result or propagate exceptions.
                return await task.ConfigureAwait(false);
            }
        }
    }
