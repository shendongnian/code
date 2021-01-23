    double[] doubles = { 2, 6, 7, 8, 1, 0, 8, 9, 5, 4};
    string[] strings = doubles.Select(n => n.ToString()).ToArray();
    Array.Sort(doubles, strings);
    for (int i = 0; i < doubles.Length; ++i)
        Console.WriteLine(doubles[i] + ": " + strings[i]);
