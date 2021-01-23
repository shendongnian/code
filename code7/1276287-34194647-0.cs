    public static List<int> GenerateRandom(int count)
    {
        var result = new HashSet<int>();
        while (result.Count < 50)
        {
            result.Add(random.Next());
        }
        return result.ToList();
    }
