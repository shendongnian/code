    static void Step2()
    {
        double result = 10000000d;
        var maxValue = Int32.MaxValue;
        for (int i = 1; i < maxValue; i++)
        {
            result /= i;
        }
        Console.WriteLine("Step2");
    }
