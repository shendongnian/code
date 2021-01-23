    using (transformBlock.LinkTo(outputBlock, new DataflowLinkOptions { PropagateCompletion = true }))
    {
        for (int i = 0; i < 40; i++)
        {
            Thread.Sleep(100); // simulating new item retrieval delay
            Interlocked.Increment(ref total);
            Interlocked.Increment(ref itemsProcessing);
            transformBlock.SendAsync(i).Wait();
        }
        Console.WriteLine("Enqueued");
        transformBlock.Complete();
        outputBlock.Completion.Wait();
        Console.WriteLine("Finish");
    }
