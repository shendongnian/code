    int[] a = {2, 3, 1};
    var b = a
        .Select((item, index) => new { item, index })
        .OrderBy(x => x.item)
        .Select(x => x.index)
        .ToArray();
    int[] c = new int[b.Length];
    for (int i = 0; i < b.Length; ++i)
        c[b[i]] = i;
    Console.WriteLine(string.Join(", ", c)); // Prints 1, 2, 0
