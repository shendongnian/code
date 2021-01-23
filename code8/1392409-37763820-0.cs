    Console.WriteLine("--------------------");
    Console.WriteLine("---LOGIN TERMINAL---");
    Console.WriteLine("--------------------");
    System.Threading.Thread.Sleep(1000);
    Console.WriteLine("/Log In");
    Console.WriteLine("/Create New User");
    Console.WriteLine("/Delete User");
    
    var userInput = Convert.ToString(Console.ReadLine());
    if(userInput == "Log In") // input check here
    {
    	Console.WriteLine("Enter User Name");
    	var userName = Console.ReadLine();
    	Console.WriteLine("Enter User Password:");
    	var password = Console.ReadLine();
    	Console.WriteLine("User Name: {0}, Password: {1}", userName, password);
    }
