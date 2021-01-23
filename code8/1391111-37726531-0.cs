    var text = @"Case 1: Bug A is resolved (XID: X015)
    Case 2: Bug B is resolved (ZID: X016)
    Case 3: Bug C is resolved (Data issue) (SID: X017)";
    // Instantiate the regular expression object.
    Regex r = new Regex(@"\([^)]*\)", RegexOptions.Multiline);
    // Match the regular expression pattern against a text string.
    var matches = r.Matches(text);
    if(matches.Count > 0)
    {
         var last_match = matches[matches.Count - 1];
         Console.WriteLine(last_match.Groups[0].Value);
    }
