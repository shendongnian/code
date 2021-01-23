    string pattern = @"(?<id>\d+) \| (?<name>§.+?§) \| (?<date>\d{4}-\d\d-\d\d \s \d\d:\d\d:\d\d) \| (?<desc>§.*?§)";
    Regex regex = new Regex(pattern, RegexOptions.IgnorePatternWhitespace | RegexOptions.Singleline);
    string text = File.ReadAllText("test.txt", Encoding.GetEncoding(1251));
    text = text.Split(new string[] { Environment.NewLine }, 2, StringSplitOptions.None)[1];
    var matches = regex.Matches(text);
    foreach (Match match in matches)
    {
        Console.WriteLine(match.Groups["id"].Value);
        Console.WriteLine(match.Groups["name"].Value.Trim('§'));
        Console.WriteLine(match.Groups["date"].Value);
        Console.WriteLine(match.Groups["desc"].Value.Trim('§'));
        Console.WriteLine();
    }
