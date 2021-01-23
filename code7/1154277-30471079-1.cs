    foreach (var msg in batchingQueue.GetConsumingEnumerable())
    {
        Console.WriteLine("Completing message");
        msg.Complete();
    }
