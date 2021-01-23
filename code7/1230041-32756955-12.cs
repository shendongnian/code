    List<int> ints = Enumerable.Range(1, 10).ToList();
    var test = new ReadOnlyListSlice<int>(ints, 4, 7);
    foreach (var i in test)
        Console.WriteLine(i); // 5, 6, 7, 8
    Console.WriteLine();
    for (int i = 1; i < 3; ++i)
        Console.WriteLine(test[i]); // 6, 7
