    r = new Regex("Space(?<entry>[0-9]{1,3})", RegexOptions.ExplicitCapture);
    bracketedGrps = rxPairedRoundBrackets.Matches(r.ToString()).Cast<Match>().Select(p => p.Groups[1].Value);
    GroupDict = r.GetGroupNames().Zip(r.GetGroupNumbers(), (s, i) => new { s, i })
                                 .ToDictionary(item => item.s, item => item.i);
    foreach (Match m in r.Matches("Space123"))
    {
       var id = "entry";
       var grp = m.Groups[id];
       var groupThatMatched = bracketedGrps.ElementAt(GroupDict[id] - 1);
    }
