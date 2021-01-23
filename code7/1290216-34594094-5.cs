    int number;
    if (!Int32.TryParse(Console.ReadLine(), out number))
    {
        Console.WriteLine("This only works with numbers!");
        continue;  // prompt the user again
    }
    if (number < gameNumber)
