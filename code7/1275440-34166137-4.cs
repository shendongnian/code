    List<List<string>> nestedList = new List<List<string>>();
    nestedList.Add(new List<string> { "test1" } );
    nestedList.Add(new List<string> { "test2" } );
    nestedList.Add(new List<string> { "test3" } );
    
    List<string> firstList = nestedList[0]; // Here's your new List<string> { "test1" }
    if (firstList[0] == "test1")
    {
        Console.WriteLine("Test 1!");
    }
