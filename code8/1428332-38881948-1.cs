    var queue = new Lazy<ThreadSafeQueue<int>>(() => new ThreadSafeQueue<int>());
    
    Parallel.For(0, 10000, i =>
    {
        
        else if (i % 2 == 0)
            queue.Value.Enqueue(i);
        else
        {
            int item = -1;
            if (queue.Value.TryDequeue(out item) == true)
                Console.WriteLine(item);
        }
    });
