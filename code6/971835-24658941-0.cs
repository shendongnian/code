    Console.WriteLine("Please enter your age (1-120):");
    int nAge;
    while(true)
    {
        string sAge = Console.ReadLine();
        if(!int.TryParse(sAge, out nAge))
        {
            Console.WriteLine("You did not enter a valid age - try again.");
            continue;
        }
        if(nAge <= 0 || nAge > 120)
        {
            Console.WriteLine("Please enter an age between 1 and 120");
            continue;
        }
        break;
    }
    // At this point, nAge will be a value between 1 and 120
