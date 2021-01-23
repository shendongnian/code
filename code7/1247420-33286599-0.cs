    string answer = String.Empty;
    do
    {
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("1. Eat");
        Console.WriteLine("2. Drink");
        Console.WriteLine("3. Play");
        answer = Console.ReadLine();
    } while (answer != "1" && answer != "2" && answer != "3");
    //handle answer here
