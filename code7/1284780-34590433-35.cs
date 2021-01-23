    async Task MessageQueueWithTPLDataflow()
    {
        // Set up our queue.
        BufferBlock<Message> queue = new BufferBlock<Message>();
        // Set up our processing stage (consumer).
        ExecutionDataflowBlockOptions options = new ExecutionDataflowBlockOptions {
            CancellationToken = CancellationToken.None, // Plug in your own in case you need to support cancellation.
            MaxDegreeOfParallelism = 4
        };
        ActionBlock<Message> consumer = new ActionBlock<Message>(m => ProcessMessageAsync(m), options);
        // Link the queue to the consumer.
        queue.LinkTo(consumer, new DataflowLinkOptions { PropagateCompletion = true });
        // Wire up our producer.
        Task producer = Task.Run(async () =>
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    queue.Post(new Message());
                    await Task.Delay(10).ConfigureAwait(false);
                }
            }
            finally
            {
                // Signal to the consumer that there are no more items.
                queue.Complete();
            }
        });
        await consumer.Completion.ConfigureAwait(false);
    }
    Task ProcessMessageAsync(Message message)
    {
        return Task.Delay(40);
    }
