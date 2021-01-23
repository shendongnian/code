    int userGuess;
    
    if(int.TryParse(Console.ReadLine(), out userGuess))
    {
        ... do your logic
    }
    else
    {
        Console.WriteLine("Not a number");
    }
