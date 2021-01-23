    static void Main()
    {
        double runningTotal = 0;
        double next;
        var iterations = 0;
        Console.Write("Enter double: ");
        while (double.TryParse(Console.ReadLine(), out next) && next != 0 && iterations < 100)
        {
            runningTotal += next;
            iterations++;
            Console.Write("Enter double: ");
        }
        Console.WriteLine("You entered {0} number(s) giving a total value of {1}", iterations+1, runningTotal);
        Console.Read();
    }
