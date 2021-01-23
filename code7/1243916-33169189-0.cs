    int hoursOfSleep;
    while(!int.TryParse(Console.ReadLine(), out hoursOfSleep)
    {
        Console.WriteLine("Invalid Hours !! ");
        Console.WriteLine(" Enter hours in integer");
    }
    
    Console.WriteLine("hello " + name);
    
    if (hoursOfSleep > 8)
    {
        Console.WriteLine("you are well rested");
    }
    else
    {
        Console.WriteLine("you need sleep");
    }
