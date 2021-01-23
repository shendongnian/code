    public void Map()
    {
        var obj = new Dictionary<K, MutableInt>();  // Unable to define new instance of T
        map = obj;      // Unable to convert T to base class
    }
