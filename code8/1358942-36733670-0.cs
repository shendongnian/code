    bool loop;
        
    do
    {
        Console.WriteLine("question blah blah blah");
    
        string choice1 = "blah1";
        string choice2 = "blah2";
        string choice3 = "blah3";
        
        
        string userChoice = Console.ReadLine();
          
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
                loop = true;
                break;
        }
    } while(loop);
