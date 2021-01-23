    do {
       Console.WriteLine("Please Provide a State Name: ");
       state = Console.ReadLine();
    } while (!RegEx.IsMatch(state, @"^[a-z]{2}$", RegexOptions.IgnoreCase)) 
    
