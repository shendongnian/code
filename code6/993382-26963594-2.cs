    SortedDictionary<float, string> neededMap = new SortedDictionary<float, string>();
    neededMap.Add(1.0f, "first!");
    neededMap.Add(3.0f, "second!");
    Console.WriteLine("see how useful this is? (looking up indices that aren't in my map)");
    Console.WriteLine(neededMap.FloorEntry(2.0f));
    Console.WriteLine(neededMap.CeilingEntry(2.0f));
