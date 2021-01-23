    string input = // ...
    string pattern = @"(^|[\r\n])(\w{1,3} )?(11|\d): (?<line>[^\r\n]+)(\r?\n\s+(?<line>[^\r\n]+))*";
    foreach (Match m in Regex.Matches(input, pattern))
        {
        if(m.Success)
            {
            string entry = string.Join(Environment.NewLine, 
                m.Groups["line"].Captures.Cast<Capture>().Select(x=>x.Value));
            // ...
            }
        }
