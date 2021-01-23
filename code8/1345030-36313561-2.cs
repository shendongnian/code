    public int GetSumOfLevel(int level, List<Details> details)
    {
        return details.Where(x => x.Level == level).Sum(x => x.Sal);
    }
...
        Console.WriteLine(GetSumOfLevel(1, data)); // result  3
        Console.WriteLine(GetSumOfLevel(2, data)); // result  4
        Console.WriteLine(GetSumOfLevel(3, data)); // result  9
