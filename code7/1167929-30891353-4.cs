    public static string[][] ValuesAdd = 
        {
            new [] { "a", "b", "c" },
            new [] { "1", "2", "3" },
            new [] { "x", "y", "z" },
        };
    public static void NestedForeach() 
    {
        // Note that count isn't required anymore as we're using
        // ValuesAdd.Length as the count
        NestedForeachRecursive(string.Empty, 0);
    }
    
    public static void NestedForeachRecursive(string prefix, int depth)
    {
        foreach (var item in ValuesAdd[depth])
        {
            var nextDepth = depth + 1;
            var nextPrefix = prefix + item;
            if (nextDepth < ValuesAdd.Length)
                NestedForeachRecursive(nextPrefix, nextDepth);
            else
                Console.WriteLine(nextPrefix);
        }
    }
