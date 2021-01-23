    string[] cache = Cache["names"] as string[];
    if(names == null)
    {
    cache= DB.GetCache();
    Cache["names"] = cache;
    }
    return cache;
}
