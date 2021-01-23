    Console.WriteLine("Enter the plain text: ");
    
    char[] letters = Console.ReadLine()
        .ToUpper()
        .Where(c => Char.IsLetter(c))
        .ToArray();
