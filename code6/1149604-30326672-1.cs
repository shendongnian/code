    public static IEnumerable<int> PrimeNumbers(int NumberPrimes)
    {
        yield return 2;
        for (int i = 3; i < NumberPrimes; i = i + 2)
        {
            bool IsPrime = true;
            System.Threading.Tasks.Parallel.For(2, i, (o, state) =>
            {
                if (i % o == 0)
                {
                    IsPrime = false;
                    state.Break();
                }
            });
            if (IsPrime)
            {
                yield return i;
            }
        }
    }
