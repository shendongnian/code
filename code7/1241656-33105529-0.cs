    var predictions = db.Predictions.GroupBy(g => g.AspNetUser.UserName)
    .Select(g => new { username= g.AspNetUser.UserName, SumPredCorrectScore = g.Sum(i => i.PredCorrectScore) })
    .Include(p => p.AspNetUser)
    .Include(p => p.Prediction1)
    .Include(p => p.Match)
    .ToList();
