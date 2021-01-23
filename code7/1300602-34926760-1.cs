    byte[] haystack = new byte[1000];
    byte[] needle   = {1, 2, 3, 4, 5, 6, 7, 8, 9};
    for (int i = 100; i <= 900; i += 100)
        Array.Copy(needle, 0, haystack, i, needle.Length);
    foreach (int index in BoyerMoore.Search(haystack, needle))
        Console.WriteLine(index);
