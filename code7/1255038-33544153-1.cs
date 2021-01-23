     public static int fact(int y)
    {
        int count = n;
        if (y <= 1)
        {
            Console.WriteLine(y);
        }
        else
        {
            count = (count * y);
            Console.WriteLine(count);
            fact(y - 1);
        }
    }
