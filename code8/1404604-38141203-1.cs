    Console.WriteLine("Hello, what is your name?");
    string name = Console.ReadLine();
    char response = YorN("Greetings, " + name + ". Would you like to read a joke? (y/n)");
    if (response == 'Y')
    {
        Console.WriteLine("Joke question?");
        Console.ReadLine();
        Console.WriteLine("Joke answer.");
    }
    else
    {
        Console.WriteLine("You're missing on all the fun! Suit yourself. Goodbye!");
    }
