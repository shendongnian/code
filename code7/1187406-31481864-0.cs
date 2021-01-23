    String stringToSplit = "hello 'Anjali', How Are You?  My name is 'John'";
    Console.WriteLine("Regex.Match()");
    for (Match match = Regex.Match(stringToSplit, "'(.*?)'"); match.Success; match = match.NextMatch())
    {
        Console.WriteLine(match.Groups[1]);    
    }
    Console.WriteLine();
    Console.WriteLine("Regex.Split()");
    string[] tokens = Regex.Split(stringToSplit, "'(.*?)'");
    foreach (string token in tokens)
    {
        Console.WriteLine(token);
    }
