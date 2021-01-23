    string url = "http://www.youtube.com/watch?v=ClcKC_U_7fM,ujmoYyEyDP8,cwRFjWdxeRQ,Z4BKV121mP4,T241s7O7-Io";
    Regex regexPattern = new Regex("(?<==|,)([^,]*)");
    Match matchResults = regexPattern.Match(url);
    while (matchResults.Success)
    {
        Console.WriteLine(matchResults.Value);
        matchResults = matchResults.NextMatch();
    }
