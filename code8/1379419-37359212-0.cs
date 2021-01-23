    bool confirmed = false;
    while(!confirmed)
    {
        Console.WriteLine("Please enter a login key.");
        string Key = Console.ReadLine();
        Console.WriteLine("You entered, " + Key + " as your login key!");
        Console.WriteLine("Are you sure you want to choose this as your login key? [yes/no]");
        string option = Console.ReadLine();
        
        if (option == "yes")
        {
            confirmed = true;
        }
        
    }
This way if option is anything but yes it will remain in the while loop.
