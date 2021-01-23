    int[] a = {2, 3, 1};
    int[] b = Enumerable.Range(0, a.Length).ToArray();
    int[] c = b.ToArray();
    Array.Sort(a, b);
    Array.Sort(b, c);
    Console.WriteLine(string.Join(", ", c)); // Prints 1, 2, 0
