        List<Class1> Scores = new List<Class1>();
        Scores.Add(new Class1 { Score = 1, TotalScore = 2, User = "A" });
        Scores.Add(new Class1 { Score = 1, TotalScore = 5, User = "B" });
        Scores.Add(new Class1 { Score = 1, TotalScore = 3, User = "C" });
        Scores = Scores.OrderByDescending(x => x.TotalScore).ToList();
