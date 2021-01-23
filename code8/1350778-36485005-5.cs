    IDictionary<IP_Range, string> myCache = new Dictionary<IP_Range, string>(new IP_RangeComparer());
    // Adding entries
    myCache.Add(new IP_Range() { MinIP = 100, MaxIP = 110 }, "A");
    myCache.Add(new IP_Range() { MinIP = 111, MaxIP = 168 }, "B");
    myCache.Add(new IP_Range() { MinIP = 169, MaxIP = 200 }, "C");
    // Reading the dictionary
    string city = myCache[new IP_Range() { MinIP = 169, MaxIP = 200 }];
