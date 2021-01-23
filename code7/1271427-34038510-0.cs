    var lines = s.Split(new[] { "\r", "\n"}, StringSplitOptions.RemoveEmptyEntries); // Split into line array
    var subset = lines.SkipWhile(p => p != "headerb") // Get to the "headerb" line
                      .Skip(1)    // Get to the line after "headerb"
                      .TakeWhile(m => m != "headerc")  // Grab the lines in the block we need
                      .ToList();
    var digits = Regex.Matches(string.Join(string.Empty, subset), "[0-9]+")
                     .Cast<Match>()
                     .Select(v => v.Value)
                     .ToList();
