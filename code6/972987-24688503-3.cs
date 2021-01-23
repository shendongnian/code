    public void TestRunLength()
    {
        var random = new Random();
    
        var runs = Enumerable.Range(int.MinValue, int.MaxValue)
                             .Select(i => random.Next(0, 10));
    
        var finalGroup = RunLength(runs)
            .FirstOrDefault(i => i.Count == 6);
    }
