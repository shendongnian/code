	string input = @"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>These masters were created using Smith J054<br>";
    Regex regex = new Regex(@"These masters were created using [a-zA-Z]+ ([a-zA-Z]\d+)");
    foreach (Match match in regex.Matches(input))
    {
        Console.Out.WriteLine("Found a match : " + match);
        if(match.Groups.Count >= 2)
            Console.Out.WriteLine("Extract " + match.Groups[1].Value);
    }
