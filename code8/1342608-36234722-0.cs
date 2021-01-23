    var input = "\"mynamesarealexandandrew\" \"mynameisalexand\"";
    var regex = new Regex(@"""[^""\\]*(?:\\.[^""\\]*)*""", RegexOptions.IgnorePatternWhitespace);
    var results = regex.Matches(input).Cast<Match>()
                       .Select(p => p.Value.Replace("we", "")
                                           .Replace("us", "")
                                           .Replace("they", "")
                                           .Replace("and", ""))
                       .ToList();
    foreach (var s in results)    // DEMO
    {
      	Console.WriteLine(s);
    }
