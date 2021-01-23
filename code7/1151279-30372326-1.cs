    string userInput = "B";
    
    bool isUpper = char.IsUpper(userInput[0]);
    char inputChar = Char.ToLowerInvariant(userInput[0]);
    if(indexLookup.ContainsKey(inputChar))
    {
        int indexOfChar = indexLookup[inputChar];
        char oppositeChar = charLookup[25 - indexOfChar];
        string result = isUpper ? Char.ToUpperInvariant(oppositeChar).ToString() : oppositeChar.ToString();
        Console.Write(result); // Y
    }
