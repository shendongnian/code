    class Score { public string Name; public int Result;}
    Score[] scores = new Score[5];
    var newScore = new Score {Name = "Foof", Result=9001};
    scores = scores
       .Where(s => s != null) // ignore empty
       .Concat(Enumerable.Repeat(newScore,1)) // add new one
       .OrderByDescending(s => s.Result)  // re-sort
       .Concat(Enumerable.Repeat((Score)null,4)) // pad with empty if needed
       .Take(5) // take top X
       .ToArray(); // back to array
    
