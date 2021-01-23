    while (!doesUserWantToLeave)
    {
        if (conversionType == "Bronze")
        {
            //....
        }
        // ...
        else if (conversionType == "Exit")
        {
            doesUserWantToLeave = true;
        }
        else
        {
            Console.WriteLine("Sorry! That was an invalid option!");
        }
        conversionType = Console.ReadLine();
    }
