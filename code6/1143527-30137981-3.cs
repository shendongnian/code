    string line = Console.ReadLine();
    
    // If the line consists of a sequence of digits, followed by whitespaces,
    // followed by another sequence of digits (doesn't handle overflows)
    if(new Regex(@"^\d+\s+\d+$").IsMatch(line))
    {
       ...   // Valid: process input
    }
    else
    {
       ...   // Invalid input
    }
