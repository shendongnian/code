    private string getColor(string value)
    {
        var matches = Regex.Matches(value, "_(.*?)_");
    
        foreach(Match match in matches)
        {
            int counter = 0;
            foreach(Group group in match.Groups)
            {
                if (counter++ == 0)
                    continue;
    
                string color = group.Value;
    
                if (!String.IsNullOrWhiteSpace(color))
                    return color.ToLower();
            }
        }
    
        return null;
    }
