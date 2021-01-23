    private static int Cominations(int allNumbers, int perGroup)
    {
        if(allNumbers > 13)
        {
            Console.WriteLine("Too big number!");
            return -1;
        }
        return Factorial(allNumbers)/Factorial(allNumbers - perGroup);
    }
    private static int Factorial(int number)
    {
        int n = 1;
        for (int i = 1; i < number; i++)
        {
            n *= i;
        }
        return n; // returns 1 when number is 0
    }
