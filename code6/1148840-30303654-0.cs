      Console.Write("Please enter your phone number: ");
      string input = Console.ReadLine();
    
      String pattern = "^\+(?:[0-9] ?){6,14}[0-9]$";
    
      Boolean isNumberValid = Regex.IsMatch(input, pattern); 
