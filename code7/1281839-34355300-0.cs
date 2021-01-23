    BlockingCollection<int> blocking_collection = new BlockingCollection<int>();
    //Create producer on a thread-pool thread
    Task.Run(() =>
    {
        int number = 0;
        while (true)
        {
            blocking_collection.Add(number++);
            Thread.Sleep(100); //producer produces ~10 items every second
        }
    });
    int max_size = 10; //Maximum items to have
    int items_to_skip = 0;
    //Consumer
    foreach (var item in blocking_collection.GetConsumingEnumerable())
    {
        if (items_to_skip > 0)
        {
            items_to_skip--; //quickly skip items (to meet the clearing requirement)
            continue;
        }
        //process item
        Console.WriteLine(item);
        Thread.Sleep(200); //Consumer can only process ~5 items per second
        var collection_size = blocking_collection.Count;
        if (collection_size > max_size) //If we reach maximum size, we flag that we want to skip items
        {
            items_to_skip = collection_size;
        }
    }
