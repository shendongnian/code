        ReadAgain:
        string str = Console.ReadLine(); 
        char option = char.Parse(str);
        //The switch itself:
        switch (option)
        {
            case 'N':
                Console.WriteLine("Creating New App...");
                break;
            case 'L':
                Console.WriteLine("Loading App...");
                break;
            case 'O':
                Console.WriteLine("Loading Options...");
                break;
            case 'Q':
                Console.WriteLine("Exiting Application...");
                System.Environment.Exit(1);
                break;
            default:
                Console.WriteLine("Invalid input.");
                Goto ReadAgain;
                break;
        }
        Console.ReadLine();
