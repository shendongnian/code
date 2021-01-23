    // initialization of singleton class
    ICacheCrow<string, string> cache = CacheCrow<string, string>.Initialize(1000);
    // adding value to cache
    cache.Add("#12","Jack");
    // searching value in cache
    var flag = cache.LookUp("#12");
    if(flag)
    {
        Console.WriteLine("Found");
    }
    // removing value
    var value = cache.Remove("#12");
