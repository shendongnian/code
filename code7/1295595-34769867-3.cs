    public static bool IsPrime(int number)
    {
        int boundary = (int)Math.Floor(Math.Sqrt(number));
        if (number == 1) return false;
        if (number == 2) return true;
        for (int i = 2; i <= boundary; ++i)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
    public void PrimeTest()
    {
        var oregex = new ORegex<int>("{0}(.{0})*", IsPrime);
        var input = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
        foreach (var match in oregex.Matches(input))
        {
            Trace.WriteLine(string.Join(",", match.Values));
        }
    }
    //OUTPUT:
    //2
    //3,4,5,6,7
    //11,12,13
