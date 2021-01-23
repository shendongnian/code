    static public BigInteger PFactorial(int n)
    {
        var range = Enumerable.Range(1, n).Select(x => (BigInteger) x).AsParallel();
        var lists = range.GroupBy(x => x/(n/Environment.ProcessorCount)).Select(x => x.AsEnumerable());
        var results = lists.Select(x => x.Aggregate(BigInteger.One, BigInteger.Multiply));
        var result = results.Aggregate(BigInteger.One, BigInteger.Multiply);
        return result;
    }
