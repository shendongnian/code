    public static void Print(int[][] matrix)
    {
        foreach (var row in matrix)
            Console.WriteLine($"[{string.Join(",", row)}]");
    }
