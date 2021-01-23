    r = new Regex(@"(?<OuterSpace>Space)(?<entry>\([0-9]{1,3}\))", RegexOptions.ExplicitCapture);
    bracketedGrps = rxPairedRoundBrackets.Matches(r.ToString()).Cast<Match>();
    var GroupDict = r.GetGroupNames().Zip(r.GetGroupNumbers(), (s, i) => new { s, i })
             .ToDictionary(item => item.s, item => item.i);
    foreach (Match m in r.Matches("My New Space(123)"))
    {
       var id = "entry";
       var groupThatMatched = bracketedGrps.ElementAt(GroupDict[id] - 1).Value;
    }
