    string docStr = "Made at Training And Doctrine (TAD)";
    string allUpperRegStr = "\\([A-Z]{2,}\\)";
    Match mUpper = Regex.Match(docStr, allUpperRegStr);
    
    if (mUpper.Success)
    {
        string remWS = mUpper.Value.Trim();
        char [] chars = remWS.toCharArray();
        IEnumerable<string> lowerUpper = from l in chars
                                         select string.Format("[{0}{1}]", Char.ToLower(l), Char.ToUpper(l));
        string regex2 = string.Format("({0})", string.Join("[a-z]+\\s", lowerUpper));
        Match mDefinition = Regex.Match(docStr, regex2);
    
        if (mDefinition.Success)
        {
            string definition = mDefinition.Value.Trim();
        }
    }
