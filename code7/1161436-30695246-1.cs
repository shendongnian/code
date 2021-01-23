    Regex quotedPattern = new Regex("\"(.+)\"");
    Match matches = quotedPattern.Match(myFullPath);
    if(matches.Groups.Count > 1)
    {
         pathOnly = matches.Groups[1];
         pathOnly = Path.GetDirectoryName(pathOnly);
    }
