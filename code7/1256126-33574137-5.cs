    var visits = db.Visits.Select(d => new
    {
        d.Id,
        d.UserId
    })
    .AsEnumerable()
    .Select(d => new
    {
        Id = d.Id,
        UserId = d.UserId,
        User = MvcApplication.GlobalUserDictionary[d.UserId]
    });
