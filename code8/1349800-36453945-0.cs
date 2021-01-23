    void Main()
    {
        var dict = new DefaultingDictionary<string, double>();
        
        dict["one"] = 1;
        
        dict["one"] += 1;
        dict["two"] += 1;
        
        Console.WriteLine(dict["one"]);
        Console.WriteLine(dict["two"]);
    }
    
    class DefaultingDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new TValue this[TKey key]
        {
            get
            {
                TValue v;
                if(TryGetValue(key, out v))
                {
                    return v;
                }
                return default(TValue);
            }
            
            set
            {
                base[key] = value;
            }
        }
    }
