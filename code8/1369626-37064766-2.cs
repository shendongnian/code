    bool loopCondition = true;
    while (loopCondition)
    {
        string mystring = null; Console.WriteLine("Enter your input : ");
        mystring = Console.ReadLine();
        switch (mystring)
        {
            case "R":
                Console.WriteLine("R");
                break;
    
            case "S":
                Console.WriteLine("S");
                break;
    
            case "T":
                Console.WriteLine("T");
                break;
            default:
                loopCondition = false;
                break;
        }
    }
