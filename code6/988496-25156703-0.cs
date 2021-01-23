    var dt = DateTime.Now.AddDays(-1);
    var results = context.Where(x=>x.EventTime >= dt)
        .GroupBy(x=>new {x.Person,x.Game})
        .Select(x=>new 
        {
            x.Key.Person,
            x.Key.Game,
            LatestScore = x.Where(d=>d.EventTime == x.Max(l=>l.EventTime))
                           .Select(d=>d.Score)
                           .FirstOrDefault()
        });
