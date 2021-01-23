    DateTime dt = new DateTime();
    bool keepGoing = true;
    while (keepGoing)
    {
        Console.WriteLine("[1] Enter date (dd/mm/yyyy)");
        Console.WriteLine("[2] Print date");
        Console.WriteLine("[3] Stop");
        int answer;
        int.TryParse(Console.ReadLine(), out answer);
        switch (answer)
        {
            case 1:
                if(!DateTime.TryParse(Console.ReadLine(), out dt))
                {
                    Console.WriteLine("Invalid Date");
                }
                break;
            case 2:
                Console.WriteLine("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
                break;
            case 3:
                keepGoing = false;
                break;
            default:
                Console.WriteLine("Incorrect Entry");
                break;
        }
    }
