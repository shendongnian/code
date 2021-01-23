    public static void Main()
    {
        byte[] haystack = new byte[10000];
        byte[] needle = { 0x00, 0x69, 0x73, 0x6F, 0x6D };
        // Put a few copies of the needle into the haystack.
        for (int i = 1000; i <= 9000; i += 1000) 
            Array.Copy(needle, 0, haystack, i, needle.Length);
        var searcher = new BoyerMoore(needle);
        foreach (int index in searcher.Search(haystack))
            Console.WriteLine(index);
    }
