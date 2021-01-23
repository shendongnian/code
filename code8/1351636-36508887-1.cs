        Console.Write("Would you like the super feet as well? ");
        string answer = Console.ReadLine();
        bool yes;
        if(answer == "yes")
            yes = true;
        else
            yes = false;
        
        if (yes == true)
        {
            Console.WriteLine("Please enter the following dims: ");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Ok, Thank you");
            Console.ReadLine();
        }
