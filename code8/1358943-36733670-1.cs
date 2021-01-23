    bool loop;
        
    do
    {
        Console.WriteLine("question blah blah blah");
    
        string choice1 = "blah1";
        string choice2 = "blah2";
        string choice3 = "blah3";
        
        string userChoice = Console.ReadLine();
          
        // Set to false by default
        loop = false;
        
        switch (userChoice)
        {
            case "1":
                //Dostuff
                break;
            case "2":
                //Dostuff
                break;
            case "3":
                //Dostuff
                break;
            default:
                Console.WriteLine("you didn't enter something i could recognize");
                // Set to true to iterate again.
                loop = true;
                break;
        }
    } while(loop);
