    List<long> results = new List<long>();
    foreach(string s in StringNum)
    {
        long val;
    
        if(long.TryParse(s, out val))
        {
            results.Add(val);
        }
    }
    long[] LongNum = results.ToArray();
