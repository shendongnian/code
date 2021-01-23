    public static int fact(int y)
    {
        if (y <= 1)
        {
            return 1;
        }
        else
        {
            return y * fact(y - 1);
        }
    }
