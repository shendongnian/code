    letter = Convert.ToChar(Console.ReadLine());
    if(hangCharacters.Any(c => c == letter))
    	Console.WriteLine("You guessed correctly!");
    else
    	Console.WriteLine("You guessed incorrectly!");
