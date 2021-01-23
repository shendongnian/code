    public static string FileLocation()
    {
        while (true)
        {
            Console.Write(">Enter '1' through '9' to choose a hand.");
            Console.Write("Enter '0' for random.");
            int fileRequest = Convert.ToInt16(Console.ReadLine());
            if (fileRequest == 0)
                fileRequest = (new Random()).Next(1, 10);
            
            switch (fileRequest)
            {
                case 1:
                    Console.WriteLine(">Loading file one.");
                    return Path.GetFullPath("Flush.txt");
                case 2:
                    Console.WriteLine(">Loading file two.");
                    return Path.GetFullPath("FourKind.txt");
                case 3:
                    Console.WriteLine(">Loading file three.");
                    return Path.GetFullPath("FullHouse.txt");
                case 4:
                    Console.WriteLine(">Loading file four.");
                    return Path.GetFullPath("Pair.txt");
                case 5:
                    Console.WriteLine(">Loading file five.");
                    return Path.GetFullPath("RoyalFlush.txt");
                case 6:
                    Console.WriteLine(">Loading file six.");
                    return Path.GetFullPath("Straight.txt");
                case 7:
                    Console.WriteLine(">Loading file seven.");
                    return Path.GetFullPath("StraightFlush.txt");
                case 8:
                    Console.WriteLine(">Loading file eight.");
                    return Path.GetFullPath("ThreeKind.txt");
                case 9:
                    Console.WriteLine(">Loading file nine.");
                    return Path.GetFullPath("TwoPair.txt");
                default:
                    Console.WriteLine("Invalid request.");
                    break;
            }
        }
    }
