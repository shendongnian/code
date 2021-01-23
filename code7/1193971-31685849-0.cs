    long a = 600851475143L;
    if (IsPrime(a))
    {
        Console.WriteLine(a);
    }
    else
    {
        double limit = Math.Sqrt(a);
        for (long b = 2; b <= limit; b++)
        {
            if (a % b != 0)
            {
                continue;
            }
            Console.WriteLine(a / b);
            break;
        }    
    }
