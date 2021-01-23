    public static void PerformActionsInParallel<T>(IEnumerable<T> elements, Action<T> action)
    {
        int threads = MaxConcurrent ?? DefaultMaxConcurrentRequests;
        // Ensure elements is only enumerated once.
        elements = elements as T[] ?? elements.ToArray();
        // Semaphore limiting the number of parallel requests
        Semaphore limit = new Semaphore(MAX_CONCURRENT, MAX_CONCURRENT);
        // Count of the number of remaining threads to be completed
        CountdownEvent remaining = new CountdownEvent(elements.Count());
    
        foreach (T element in elements)
        {
            limit.WaitOne();
            new Thread(() =>
            {
                try
                {
                    action(element);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error performing concurrent action: " + ex);
                }
                finally
                {
                    remaining.Signal();
                    limit.Release();
                }
            }).Start();
        }
        // Wait for all requests to complete
        remaining.Wait();
    }
