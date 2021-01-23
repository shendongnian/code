    byte[] haystack = new byte[] { 1, 2, 3, 4, 5, 1, 2, 3 };
    byte[] needle = new byte[] {1,2,3};
    int index = 0;
    while (index != -1)
    {
        index = SearchBytes(haystack, needle, index);
        if (index == -1)
            break;
        Console.WriteLine("Found at " + index);
        index += needle.Length;
    }
