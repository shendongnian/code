        Console.Write("Please type few numbers: ");
        dynamic[] test = Console.ReadLine().Split(charSeparators, StringSplitOptions.RemoveEmptyEntries).ToArray();
        double value = double.Parse(test[0]);
        for (int i = 1; i < test.Length; i++)
        {
            if (double.Parse(test[i]) < value)
            {
                value = double.Parse(test[i]);
            }
        }
