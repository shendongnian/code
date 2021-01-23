    using System.Collections.Concurrent;
    
    ConcurrentDictionary<int, Wrapper> wrapperDictionary;
    
    public Wrapper GetWrapper(int num)
    {
        return wrapperDictionary.GetOrAdd(num, () => new Wrapper());
    }
