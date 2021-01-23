    // Infinite loop until you get valid inputs or quit
    for(;;)
    {
        System.Console.Write("Name: ('quit' to stop)");
        String name = System.Console.ReadLine();
        if(name == "quit") return;
        if(!Checker(name, false))
        {
             // Input not valid, message and repeat
             Console.WriteLine("Invalid name length");
             continue;
        }
    
    
        System.Console.Write("Date of Birth: (quit to stop)");
        String dob = System.Console.ReadLine();
        if(dob == "quit") return;
        if(!Checker(dob, true))
        {
             // Input not valid, message and repeat
             Console.WriteLine("Invalid name length");
             continue;
        }
        // if you reach this point the input is valid and you exit the loop
        break;
    }
