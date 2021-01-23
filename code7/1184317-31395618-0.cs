    Console.Write("Enter a number: ");
        string userInput = Console.ReadLine();
        string message = (Convert.ToInt32(userInput) >= 50) ? "Your number is greater than 50" : "You number is less than 50";
        Console.WriteLine(message);
        Console.ReadLine();
