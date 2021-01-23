    bool run = true;
    while (run)
    {
        Console.Write("Type in a number: ");
        string input = Console.ReadLine();
    
        //Exit application
        if(input == "exit")
        {
            run = false;
            return;
        }
    
        //Returns true if numberStr can be parsed to an int
        int number;
        if (Int32.TryParse(input, out number))
        {
            if(number > 20)
                Console.WriteLine("Number is greater than 20!");
            else
                Console.WriteLine("Number is less than 20!");
        }
        else
            Console.WriteLine("Doesn't seem to be a number: " + number);
        
    }
    
    Console.ReadLine();
