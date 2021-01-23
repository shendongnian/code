    //we only need every match once
    var matches = Regex.Matches(source, @"\w+")
                       .OfType<Match>()
                       .Select (m => m.Groups[0].Value)
                       .Distinct();
    
    foreach (var match in matches)
    {
    	source = source.Replace(match, String.Format("\"{0}\"", match));
    }
    JObject obj = JObject.Parse(source);
