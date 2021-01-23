    //Version 1
    for (int num = 0; num < 100; num+=2)        // Two comparisons 
    {
        Console.WriteLine (num); 
    }
    //Version 2
    for (int num = 0; num < 100; num++)         // Two comparisons
    {
        if (num % 2 == 0)                       // One comparison
        {
            Console.WriteLine (num);
        }   
    }
