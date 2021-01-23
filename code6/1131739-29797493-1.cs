    double[] doubles = { 2, 6, 7, 8, 1, 0, 8, 9, 5, 4};
    string[] strings = doubles.Select(n => n.ToString()).ToArray();
    int[]    indices = Enumerable.Range(0, doubles.Length).ToArray();
    Array.Sort(doubles, indices);
    for (int i = 0; i < doubles.Length; ++i)
        Console.WriteLine(doubles[i] + ": " + strings[indices[i]]);
