    bool stop; // false by default
    while (!stop)
    {
        Console.WriteLine("Please verify your birth date");
        userValueTwo = Console.ReadLine();
         try
         {
            DateTime birthdayTwo = DateTime.Parse(userValueTwo);
         }
         catch
         {
             Console.WriteLine("You did not enter a valid format.");
             Console.ReadLine();
         }
         if (userValueTwo == userValue)
         {
             Console.WriteLine("Birth date confirmed.");
             Console.ReadLine();
             stop = true;
         }
        else 
        {
            Console.WriteLine("Your birthday did not match our records. Please try again");
            Console.ReadLine();
        }
    }
