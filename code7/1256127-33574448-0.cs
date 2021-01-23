    var visits = db.Visits.Select(d => new
    {
        d.Id,
        d.UserId
    })
    .ToList()
    .Select(d => new
    {
        Id = d.Id,
        UserId = d.UserId,
        User = MvcApplication.GlobalUserDictionary[d.UserId]
    });
