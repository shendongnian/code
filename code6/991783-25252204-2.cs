    Task producer = Task.Run(() =>
    {
        if (list.Count > 0)
            Console.WriteLine("Block begin");
        foreach(var item in list)
        {
            collection.TryAdd(item);
        }
        list.Clear();
        collection.CompleteAdding();
    });
