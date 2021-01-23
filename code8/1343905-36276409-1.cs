    List<Test> tests = new List<Test>() { 
        new Test(){ No = 101 },
        new Test(){ No = 201 },
        new Test(){ No = 300 },
        new Test(){ No = 401 },
        new Test(){ No = 500 },
        new Test(){ No = 601 }
    };
    
    int[] newOrder = new int[6] { 201, 401, 300, 101, 601, 500 };
    // Create a Dictionary/hashtable so we don't have to search in newOrder repeatedly
    // It will look like this: { {201,0}, {401,1}, {300,2}, {101,3}, {601,4}, {500,5} }
    Dictionary<int, int> newOrderIndexedMap = Enumerable.Range(0, newOrder.Length - 1).ToDictionary(r => newOrder[r], r => r);
    // Order using 1 CPU
    var orderedTests = tests.OrderBy(test => newOrderIndexedMap[test.No]);
    // Order using multi-threading
    var orderedInParallelTests = tests.AsParallel().OrderBy(test => newOrderIndexedMap[test.No]);
