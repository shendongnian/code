    public static int[] genRands(int total, int max)
    {
        Random _random = new Random();
        HashSet<int> Result = new HashSet<int>();
        while (Result.Count < total)
        {
            Result.Add(_random.Next(0, max));
        }
        return Result.ToArray();
    }
