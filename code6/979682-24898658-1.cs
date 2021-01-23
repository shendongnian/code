    string data = "level=<device[195].level>&name=<device[195].name>";
    string pattern = @"
    (?<variable>[^=]+)     # get the variable name
    (?:=<device\[)         # static '=<device'
    (?<index>[^\]]+)       # device number index
    (?:]\.)                # static ].
    (?<sub>[^>]+)          # Get the sub command
    (?:>&?)                # Match but don't capture the > and possible &  
    ";
        
     // Ignore pattern whitespace is to document the pattern, does not affect processing.
    var items = Regex.Matches(data, pattern, RegexOptions.IgnorePatternWhitespace)
                    .OfType<Match>()
                    .Select (mt => new
                      {
                         Variable = mt.Groups["variable"].Value,
                         Index    = mt.Groups["index"].Value,
                         Sub      = mt.Groups["sub"].Value
                      })
                     .ToList();
    
    items.ForEach(itm => Console.WriteLine ("{0}:{1}:{2}", itm.Variable, itm.Index, itm.Sub));
    
    /* Output
    level:195:level
    name:195:name
    */
