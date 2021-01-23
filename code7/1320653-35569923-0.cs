    bool shouldRun = true;
    while(shouldRun)
    {
        switch (option)
        {
            case 'N':
                Console.WriteLine("Creating New App...");
                shouldRun = false;
                break;
            case 'L':
                Console.WriteLine("Loading App...");
                shouldRun = false;
                break;
            case 'O':
                Console.WriteLine("Loading Options...");
                shouldRun = false;
                break;
            case 'Q':
                Console.WriteLine("Exiting Application...");
                System.Environment.Exit(1);
                break;
            default:
                Console.WriteLine("Invalid input.");
                shouldRun = true;
                break;
        }
    }
