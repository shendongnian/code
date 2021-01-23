    long result = 0;
    for (long x = 100; x <= 999; x++)
    {
        for (long y = 100; y <= 999; y++)
        {
            long num = x * y;
            if (num.ToString() == StringFunctions.ReverseString(num.ToString()))
            {
                if(result < num)
                {
                result = num;
                }
            }
        }
    }
    Console.WriteLine("Result : {0}", result);
