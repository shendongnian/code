    var inputData = new[]
    {
        "Boyster S01E13 – E14",
        "Mysteries at the Museum S08E08",
        "Mysteries at the National Parks S01E07 – E08",
        "The Last Days Ofâ€¦ S01E06",
        "Born Naughty? S01E02",
        "Have I Got News For You S49E07",
        "Ellen 2015.05.22 Joseph Gordon Levitt [REPOST]",
        "The Soup 2015.05.22 [mp4]",
        "Big Brother UK Live From The House (May 22, 2015)",
        "Alaskan Bush People S02 Wild Times Special",
        "500 Questions S01E03"
    };
    var re = new Regex(@"
        ^\s*
        (?<name>.*?)
        (?<info> \s+ (?:
            (?<episode>S\d+(?:E\d+(?:\s*\p{Pd}\s*E\d+)?)?)
            |
            (?<date>\d{4}\.\d{1,2}\.\d{1,2})
            |
            \(?(?<date>(?i:January|February|March|April|May|June|July|August|September|October|November|December)\s*\d{1,2},\s*\d{4})\)?
            |
            \[(?<format>.*?)\]
            |
            (?<extra>(?(info)|(?!)).*?)
        ))*
        \s*$
    ", RegexOptions.IgnorePatternWhitespace);
    foreach (var input in inputData)
    {
        Console.WriteLine();
        Console.WriteLine("--- {0} ---", input);
        var match = re.Match(input);
        if (!match.Success)
        {
            Console.WriteLine("FAIL");
            continue;
        }
        foreach (var groupName in re.GetGroupNames())
        {
            if (groupName == "0" || groupName == "info")
                continue;
            var group = match.Groups[groupName];
            if (!group.Success)
                continue;
            foreach (Capture capture in group.Captures)
                Console.WriteLine("{0}: '{1}'", groupName, capture.Value);
        }
    }
