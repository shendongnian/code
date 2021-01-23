    chatch
    {
        ErrorWriter(new int[3] { number1, number2, number3 });
    }
    (...)
    private static void ErrorWriter(int[] numbers)
    {
        int index = 1;
        foreach(var i in numbers)
        {
            Console.WriteLine("number" + index.ToString() + " = " + i.ToString());
        }
    }
