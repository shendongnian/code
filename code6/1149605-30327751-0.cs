    static IEnumerable<int> PrimeNumbers(int n)
    {
        return Enumerable.Range(2, int.MaxValue - 2)
                         .Where(i => ParallelEnumerable.Range(2, Math.Max(0, (int)Math.Sqrt(i) - 1))
                                                       .All(j => i % j != 0))
                         .Take(n);
    }
