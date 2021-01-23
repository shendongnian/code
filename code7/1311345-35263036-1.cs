    bool nameValidation = false;
    while (nameValidation == false) {
    Console.Write("Enter your name: ");  // Asks for your name
    userName = Console.ReadLine();
    
    if (Regex.IsMatch(userName, @"^[a-zA-Z- ]+$"))  // Validates the input containts characters and/or spaces
     {
        nameValidation = true;              
     }
    else  // Error message if the input is not valid
     {
        Console.Clear();  // Clear screen
        Console.WriteLine("Please enter a valid name.");
        nameValidation = false;
      }
    }
