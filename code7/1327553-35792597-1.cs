    Regex reg = new Regex("\"([^\"]*?)\"");
    List<string> elements = new List<string>();
    var matches = reg.Matches(theExpression);
    foreach(Match match in matches)
    {
        var theData = match.Groups[1].Value;
        elements.Add(theData);
    }
    //Now you have in elements a list with all 
    //the values from the string properly splitted.
