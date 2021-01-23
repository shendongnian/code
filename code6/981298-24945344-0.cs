    public IEnumerable<int> GetFactors(int input)
    {
        int first = Primes()
            .TakeWhile(x => x <= Math.Sqrt(input))
            .FirstOrDefault(x => input % x == 0);
        return first == 0
                ? new[] { input }
                : new[] { first }.Concat(GetFactors(input / first));
    }
