     string user=;
        var visits = db.Visits.AsEnumerable.Select(d => new
        {
            Id = d.Id,
            UserId = d.UserId,
            User = MvcApplication.GlobalUserDictionary[d.UserId];
        });
