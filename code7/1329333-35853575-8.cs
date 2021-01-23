    // Explicit hints to the parser to ingore any non specified matches ones outside the parenthesis(..)
    // Multiline states ^ and $ are beginning and eol lines and not beginning and end of buffer.
    // Ignore allows us to comment the pattern only; does not affect processing.
    Regex.Matches(data, pattern, RegexOptions.ExplicitCapture |
                                 RegexOptions.Multiline       |
                                 RegexOptions.IgnorePatternWhitespace)
         .OfType<Match>()
         .Select (mt => new
         		{
                    Status    = mt.Groups["Status"].Value,
         		    StartDate = DateTime.Parse(mt.Groups["Start"].Value),
         			EndDate   = DateTime.Parse(mt.Groups["End"].Value)
         		})
