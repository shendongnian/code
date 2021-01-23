    string[] allowedInput = new string[]{"black", "green", "red"};
    Console.Write("Color To Bet on: ");
    string tempColor = Console.ReadLine().ToLower();
    
    while ((String.IsNullOrWhiteSpace(tempColor)) || (!allowedInput.Contains(tempColor)))
    {
        Console.WriteLine(String.Format("Invalid color. Allowed colors are : {0}.", String.Join(", ", allowedInput)));
        tempColor = Console.ReadLine().ToLower();
    }
