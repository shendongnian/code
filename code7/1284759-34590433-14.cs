    void MessageQueueWithBlockingCollection()
    {
        // If your processing is continuous and never stops throughout the lifetime of
        // your application, you can ignore the fact that BlockingCollection is IDisposable.
        using (BlockingCollection<Message> messages = new BlockingCollection<Message>())
        {
            Task producer = Task.Run(() =>
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        // Hand over the message to the consumer.
                        messages.Add(new Message());
                        // Simulated arrival delay for the next message.
                        Thread.Sleep(10);
                    }
                }
                finally
                {
                    // Notify consumer that there is no more data.
                    messages.CompleteAdding();
                }
            });
            Task consumer = Task.Run(() =>
            {
                ParallelOptions options = new ParallelOptions {
                    MaxDegreeOfParallelism = 4
                };
                Parallel.ForEach(messages.GetConsumingEnumerable(), options, message => {
                    ProcessMessage(message);
                });
            });
            Task.WaitAll(producer, consumer);
        }
    }
    void ProcessMessage(Message message)
    {
        Thread.Sleep(40);
    }
