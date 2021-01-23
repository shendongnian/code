    using System.Text.RegularExpressions;
    using System.Linq;
    private static List<string[]> parseString(string input)
    {
        var pattern = @"Start\s+Date:\s+([0-9-]+)\s+End\s+Date:\s+([0-9-]+)\s+(?:Warranty\s+Type:\s+\w+\s+)?Status:\s+(\w+)\s*";
        return Regex.Matches(input, pattern).Cast<Match>().ToList().ConvertAll(m => new string[] { m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value });
    }
