    public static List<long> getDenoms(long n)
    {
        List<long> result = new List<long>();
        for (long i = 1; i < n; i++)
        {
            if (n % i == 0)
            {
                result.Add(i);
            }
        }
        return result;
    }
    public static long getHighestPrime(List<long> seq)
    {
        int currentHigh = 1;
        foreach (long number in seq)
        {
            List<long> temp = getDenoms(number);
            if (temp.Count == 1)
            {
                if (number > currentHigh)
                {
                    currentHigh = number;
                }
            }
        }
        return currentHigh;
    }
