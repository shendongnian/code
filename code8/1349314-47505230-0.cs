    private static int SumOfNumber(int input)
    {
        int sum = 0;
        for (int i = 1; i <= input/2; i++)
        {
            if (input%i == 0)
            {
                sum += i;
            }
        }
        return sum;
    }
