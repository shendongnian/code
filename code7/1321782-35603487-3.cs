    int[] a = {2, 3, 1};
    int[] b = Enumerable.Range(0, a.Length).ToArray();
    int[] c = new int[a.Length];
    Array.Sort(a, b);
    for (int i = 0; i < b.Length; ++i)
        c[b[i]] = i;
    Console.WriteLine(string.Join(", ", c)); // Prints 1, 2, 0
