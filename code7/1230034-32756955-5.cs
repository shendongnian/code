    List<int> ints = Enumerable.Range(1, 10).ToList();
    var test = new ListSlice<int>(ints, 4, 7);
    foreach (var i in test)
        Console.WriteLine(i); // 5, 6, 7, 8
    Console.WriteLine();
    test[2] = -1;
    for (int i = 1; i < 4; ++i)
        Console.WriteLine(test[i]); // 6, -1, 8
