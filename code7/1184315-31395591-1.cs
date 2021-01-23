    int userInputNum = 0;
    string userInput = Console.ReadLine();
    
    if (int.TryParse(userInput, out userInputNum))
    {
        string message = (userInputNum > 50) ? "Your number is greater than 50" : "You number is less than 50";
        Console.WriteLine(message);
    }
    else
    {
        //Junk user input
    }
