    using System.Text.RegularExpressions;
    string pattern = @"(CN)\=(.+)\,";
    
    MatchCollection matches = Regex.Matches(input, pattern);
    foreach (Match match in matches)
    {
        Console.WriteLine(match.Groups[1].Value);
    }
