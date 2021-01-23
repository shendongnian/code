    Food foodChoice;
    while (!Enum.TryParse(Console.ReadLine(), true, out foodChoice)
        || !Enum.IsDefined(typeof(Food), foodChoice))
    {
        Console.WriteLine("Not a valid choice.");
    }
