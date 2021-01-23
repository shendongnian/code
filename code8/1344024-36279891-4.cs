    // get members count for specific cluster id
    public int GetCount(int id)
    {
         return _dict[id].Count;
    }
    
    // get members count for all clusters
    public Dictionary<int,int> GetCounts()
    {
        return _dict.ToDictionary(k=>k.Key,v=>v.Value.Count);
    }
