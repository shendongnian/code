    Regex quotedPattern = new Regex("([\"'])(?:(?=(\\?))\2.)*?\1");
    Match matches = quotedPattern.Match(myFullPath);
    if(matches.Groups.Count > 0)
    {
         pathOnly = matches.Groups[0];
         pathOnly = Path.GetDirectoryName(pathOnly);
    }
