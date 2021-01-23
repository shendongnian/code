    public static bool IsPrime(long number)
    {
        if ((number & 1) == 0)
        {
            return number == 2;
        }
        double limit = Math.Sqrt(number);
        for (int i = 3; i <= limit; i += 2)
        {
            if ((number % i) == 0)
            {
                return false;
            }
        }
        return number != 1;
    }
