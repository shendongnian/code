    String input = @"Del Mar, CA, 92014";
    Regex rgx = new Regex(@"([a-zA-Z\s]*),*\s*([a-zA-Z]{2}),*\s*([0-9]{5,10})\s*");
    foreach (Match m in rgx.Matches(input))
    {
    Console.WriteLine(m.Groups[1].Value);
    Console.WriteLine(m.Groups[2].Value);
    Console.WriteLine(m.Groups[3].Value);
    }
