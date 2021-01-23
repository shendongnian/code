    ConcurrentBag<int> cb = new ConcurrentBag<int>();
        cb.Add(1);
        cb.Add(2);
        cb.Add(3);
        // Consume the items in the bag
        int item;
        while (!cb.IsEmpty)
        {
            if (cb.TryTake(out item))
                Console.WriteLine(item);
            else
                Console.WriteLine("TryTake failed for non-empty bag");
        }
