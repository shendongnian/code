    string[] lines = File.ReadAllLines(Authentication.AuthenticationFileName);
    // Get the position of the = sign within each line
    var pairs = lines.Select(l => new { Line = l, Pos = l.IndexOf("=") });
    // Build a dictionary of key/value pairs by splitting the string at the = sign
    var dictionary = pairs.ToDictionary(p => p.Line.Substring(0, p.Pos), p => p.Line.Substring(p.Pos + 1));
    // Now you can retrieve values by key:
    var value1 = dictionary["key1"];
