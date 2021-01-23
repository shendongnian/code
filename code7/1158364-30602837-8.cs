    private static string ReplaceValueRegex(string theString, string key, string value)
    {
        // This is the group you're replacing ---|
        //                                       V
        string pattern = @"(define\s*\(.*,\s*')(\w*)('\s*\)\s*;)";
        MatchCollection mc = Regex.Matches(theString, pattern);
        for (int i = 0; i < mc.Count; i++)
        {
            if (mc[i].Value.Contains(key))
            {
                string stringToReplace = mc[i].Value;
                string replacementString = Regex.Replace(stringToReplace, pattern, String.Format("$1{0}$3", value));
                theString = theString.Replace(stringToReplace, replacementString);
            }
        }
        return theString;
    }
