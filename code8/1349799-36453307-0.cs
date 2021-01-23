    List<string> Input = new List<string>() { "AAA", "BB", "AAA+15d", "BB-205w" };
    string Pattern = @"^(AAA|BB)([+-]\d+[dw])*$";
    foreach (string item in Input)
    {
        Console.WriteLine(Regex.IsMatch(item, Pattern));
    }
