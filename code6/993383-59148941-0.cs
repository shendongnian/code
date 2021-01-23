    SortedDictionary<float, string> neededMap = new SortedDictionary<float, string>();
    
    neededMap.Add(1.0f, "first!");
    neededMap.Add(3.0f, "second!");
    //FloorEntry
    neededMap.FirstOrDefault(k => k.Key < 2.0f);
    //CeilingEntry
    neededMap.FirstOrDefault(k => k.Key > 2.0f);
