     searchPattern = "abc*xyz";
    
     inputText = "SomeTextAndabc*xyz";
----------
     public bool Contains(string searchPattern,string inputText)
      {
        string regexText = WildcardToRegex(searchPattern);
        Regex regex = new Regex(regexText , RegexOptions.IgnoreCase);
        
        if (regex.IsMatch(inputText ))
        {
            return true;
        }
            return false;
     }
