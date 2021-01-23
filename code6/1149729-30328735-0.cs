    string pattern = @"(?<key>\w+)=(?<value>\w+)";
    Regex rgx = new Regex(pattern);
    MatchCollection matches = rgx.Matches(input);
    Dictionary<string, List<string>> results = new Dictionary<string, List<string>>();
    foreach (Match item in matches)
    {
        if (!results.ContainsKey(item.Groups["key"].Value)) {
            results.Add(item.Groups["key"].Value, new List<string>());
        }
        results[item.Groups["key"].Value].Add(item.Groups["value"].Value);
    }
    foreach (var r in results) {
        Console.Write("{0}=[{1}]", r.Key, string.Join(", ", r.Value));
    }
