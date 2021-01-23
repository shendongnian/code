    private static void UseDict()
    {
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();
        int number;
        if (!int.TryParse(input, out number))
        {
            // Error handling here.
        }
        var userNumber = int.Parse(input);
        Console.WriteLine("\n" + "Number Occurrences");
        var dict = new Dictionary<int, int>();
        Random randNum = new Random((int)DateTime.Now.Ticks);
        for (int counter = 0; counter < userNumber; counter++)
        {
            var generatedNumber = randNum.Next(0, 10);
            if (!dict.ContainsKey(generatedNumber))
            {
                // Create key.
                dict.Add(generatedNumber, 0);
            }
            // Increase count.
            dict[generatedNumber]++;
        }
        for (int i = 1; i < 10; i++)
        {
            var count = dict.ContainsKey(i) ? dict[i] : 0;
            Console.WriteLine("{0} - {1}", i, count);
        }
        Console.ReadKey();
    }
