    bool loopCondition = true;
    while (loopCondition)
    {
        string mystring = null; Console.WriteLine("Enter your input : ");
        mystring = Console.ReadLine();
        switch (mystring)
        {
            case "R":
            case "S":
            case "T":
                Console.WriteLine(mystring);
                break;
            default:
                Console.WriteLine("Invalid Entry.. Exiting");
                loopCondition = false;
                break;
        }
    }
