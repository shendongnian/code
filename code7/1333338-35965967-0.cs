    for (var i = 0; i <= 11; i++)
    {
        month = startDate.AddMonths(i);
        var scm = new ScorecardMonth { 
                            TheMonth = month, //this is a DateTime..
                            Scorecards = new List<Scorecard>()
        };
        scorecardsInMonth = scorecards.FindAll(a => a.TheMonth = month)
                                      .OrderBy(b => b.GoalType));
        scm.Scorecards.AddRange(scorecardsInMonth);
        scorecardMonths.Add(scm);
    }
