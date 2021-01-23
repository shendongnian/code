    var response = Console.ReadLine(); 
            
    // If above Console.ReadLine gets a valid integer
    // the following while loop won't never executed    
    while (!int.TryParse(response, out numSeatReserveLucy)) 
    { 
        Console.WriteLine("Sorry, didn't get a number"); 
        response = Console.ReadLine(); 
    }
