    string regex = @"[E](((\d{1,2})))[-][E]?(\d{1,2})";
    string s = "S03E01-E03";
    Regex rgx = new Regex(regex);
    string[] splitResults = rgx.Split(s);
    foreach (var str in splitResults)
    {
        Console.WriteLine(str);
    }
    Console.ReadLine();
