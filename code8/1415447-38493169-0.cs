    public myoldClass(string a, string b, IMemcache memcache = null)                  
    {
        _a = a; 
        _b = b; 
        _memcache = memCache ?? new Memcache(); 
    }
