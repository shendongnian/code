    public void Test()
    {
        var itemA = VNodeClassID.Default;
        var itemB = VNodeClassID.Watermellon;
        bool results = IsCompatible(itemA, itemB);
        Console.WriteLine("{0}: {1}-{2}", results, itemA, itemB);            
    }
