    List<List<string>> nestedList = new List<List<string>>();
    nestedList.Add(new List<string> { "test1" } );
    nestedList.Add(new List<string> { "test2" } );
    nestedList.Add(new List<string> { "test3" } );
    
    if (nestedList[0][0] == "test1")
    {
        Console.WriteLine("Test 1!");
    }
