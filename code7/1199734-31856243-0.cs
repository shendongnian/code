    MemoryCache cache = new MemoryCache("C");
    CacheItemPolicy policy = new CacheItemPolicy
    {
        UpdateCallback = null,
        SlidingExpiration = new TimeSpan(0, 0, 5)
    };
    cache.Add("key", "value", policy);
    Console.WriteLine("1) " + cache.Get("key")); // Prints `1) value`
    
    System.Threading.Thread.Sleep(5250); // Wait for "key" to expire
    Console.WriteLine("2) " + cache.Get("key")); // Prints `2) `
    // Just showing the the cache still works once an item expires.
    cache.Add("key2", "value2", policy);
    Console.WriteLine("3) " + cache.Get("key2")); // Prints `3) value2`
    
    System.Threading.Thread.Sleep(5250); // Wait for "key2" to expire
    Console.WriteLine("4) " + cache.Get("key2")); // Prints `4) `
