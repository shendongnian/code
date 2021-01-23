    var reg = new Regex("(\\d+)$");
    var matches = reg.Matches("some string 0123");
    List<string> found = new List<string>();
    if(matches != null)
    {
        foreach(Match m in matches)
            found.Add(m.Groups[1].Value);
    }
    //do whatever you want with found
