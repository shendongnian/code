    string[] allowedInput = new String[]{"black", "green", "red"};
    Console.Write("Color To Bet on: ");
    string tempColor = Console.ReadLine().ToLower();
    
    while ((String.IsNullOrWhiteSpace(tempColor)) || (!allowedInput.Contains(tempColor)))
    {
        Console.WriteLine(string.Format("Invalid color. Allowed colors are : {0}.", string.Join(", ", allowedInput)));
        tempColor = Console.ReadLine().ToLower();
    }
