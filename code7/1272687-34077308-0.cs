    private readonly List<ThreePropertyHolder<string, string, string>> 
                _registeredValues = new List<ThreePropertyHolder<string, string, string>>();
    
    private Dictionary<string, List<object>> _collection = new 
                Dictionary<string, List<object>>();
    
    public Dictionary<string, List<object>> BlaBlaMethod()
    {
        foreach (var reValues in _registeredValues)
        {
            if (_collection.ContainsKey(reValues.Value2))
            {
               _collection[reValues.Value2] = new List<object>{reValues.Value3};
            }
            else
            {
               _collection.Add(
                   reValues.Value2, 
                   new List<object> { reValues.Value3 }
               );
            }
        }
    }
