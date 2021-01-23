    public static void GetPattern(List<string> values)
    {
        var years = new Dictionary<string, List<string>>();
        foreach(var value in values)
        {
            if(value.Contains("2008")) 
            {
                if(!years.ContainsKey("2008")) years.Add("2008", new List<string>());
                years["2008"].Add(value);
            }
            if(value.Contains("2009")) 
            {
                if(!years.ContainsKey("2009")) years.Add("2009", new List<string>());
                years["2009"].Add(value);
            }
            // Add for each year you want to track.
        }
        // Do something with your pattern.
     }
