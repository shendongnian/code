    string pattern = @"
    ^            # Beginning of line (anchor)
    /            # / anchor
    [^-]+        # Anything not a dash.
    -            # Anchor dash
    [^/]+        # Anything not a /
    /            # / anchor
    [^/]+        # Anything not a /
    /            # / anchor
    [12][90]\d\d # Allow only a `date` field of 19XX or 20XX.
    ";
    
    // IgnorePatternWhitespace *only* allows us to comment the pattern 
    // and place it on multiple lines (space ignored)
    // it does not affect processing of the data.
    var validator = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
    
    validator.IsMatch("/ -test/test/2016/April"); // True
    validator.IsMatch("/ -test/test/2016");       // True
    validator.IsMatch("/ -test/test/1985/April"); // True
    validator.IsMatch("/ -2017/test/1985/April"); // True
    // Negative Tests
    validator.IsMatch("/ -2017/test/WTF/April");       // False
    validator.IsMatch("/jabberwocky/test/1985/April"); // False, no dash!
    validator.IsMatch("////April");                    // false
    validator.IsMatch("///2016/April");                // False because no text between `/`
    validator.IsMatch("/ -test/test/ 2016/April");     // False because pattern 
                                                      // does not allow a space
