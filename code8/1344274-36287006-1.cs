    public static string getBetween(string strSource, string strStart, string strEnd)
    {
        string pattern = string.Format("{0}((.|\n|\r)*?){1}", strStart, strEnd);
        Regex r = new Regex(pattern);
        var matchCollection = r.Matches(strSource);
        //you can iterate through collection
        foreach (Match match in r.Matches(strSource))
        {
            string textBetweenTags = match.Groups[1].ToString();
            //your logic here
        }
        //or return second value you want
        if (matchCollection.Count >= 2)
        {
            return matchCollection[1].Groups[1].ToString();
        }
        else
        {
            return "";
        }
    }
