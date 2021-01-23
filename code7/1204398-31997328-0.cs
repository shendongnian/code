    int menuOption;
    do
    {
        Console.WriteLine("Welcome to my Battle Runners game!");
        Console.WriteLine("");
        Console.WriteLine("Chose an option from the list.");
        Console.WriteLine("1. Start Game");
        Console.WriteLine("2. About");
        Console.WriteLine("3. Credits and Information");
        Console.WriteLine("4. Quit");
        String stringMenuOption = Console.ReadLine();
        menuOption = Convert.ToInt32(stringMenuOption);
        switch (menuOption)
        {
            case 1:
                Console.WriteLine("");
                Console.WriteLine("Loading the game...");
                //all game code goes here
                break;
            case 2:
                Console.WriteLine("");
                Console.WriteLine("Battle Runners, developed by " + author +                 " is a text adventure that follows the life of a soldier in war.");
                Console.WriteLine("");
                break;
            case 3:
                Console.WriteLine("");
                Console.WriteLine("Author(s): " + author);
                Console.WriteLine("Version: " + version);
                Console.WriteLine("Date created: " + created);
                break;
            case 4:
                break;
            default:
                Console.WriteLine("");
                Console.WriteLine("You typed something incorrect!");
                break;
        }
    } while (menuOption != 4);
