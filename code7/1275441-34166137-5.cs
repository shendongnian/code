    List<List<string>> nestedList = new List<List<string>>();
    nestedList.Add(new List<string>());
    nestedList.Add(new List<string>());
    nestedList.Add(new List<string>());
    
    if (nestedList[0][0] == "test1") // Index was out of range. Must be non-negative and less than the size of the collection.Parameter name: index
    {
        Console.WriteLine("Test 1!");
    }
