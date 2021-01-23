    Task producer = Task.Run(() =>
    {
        if (list.Count > 0)
            Console.WriteLine("Block begin");
        while(list.Any())
        {
            var firstItem = list.First();
            collection.TryAdd(firstItem);
            list.Remove(firstItem);
        }
        collection.CompleteAdding();
    });
