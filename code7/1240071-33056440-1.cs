    private int[] primefactors(int value)
    {
        if (value < 0)
        {
            throw new Exception("Value can't be less than 0.");//Make sure value is not less than 0.
        }
        List<int> primefactors = new List<int>();
        for(int i = 2; i < value; i++)
        {
            if (value % i == 0 && IsPrimeNumber(i))//If the remainder of "value" divided by "i" is equal to 0 and "i" is a prime number.
            {
                factors.Add(i);
            }
        }
        return primefactors.ToArray();
    }
