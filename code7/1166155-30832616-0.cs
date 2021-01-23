    while (true) {
        Console.WriteLine("Please, Enter your Character Name!");
        string name = Console.ReadLine();
        Console.WriteLine("Is " + name + " correct? (y) or would you like to change it (n)?");
        string input = Console.ReadLine();
        if (input == "y") {
            break;
        }
    }
