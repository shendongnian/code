    public static long Fibon(long num)
    {
        if (num == 1)
        {
            return 1;
        }
        else if (num == 2)
        {
            return 1;
        }
        return fibon(num - 1) + fibon(num - 2);
    }
