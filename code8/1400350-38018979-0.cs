    var query =
        from a in db.Application
        group a by a.Grade.Description into g
        select new
        {
            Grade = g.Key,
            Pending = g.Sum(a => a.ApplicationStatusId == 1 ? 1 : 0),
            Accepted = g.Sum(a => a.ApplicationStatusId == 2 ? 1 : 0),
            Rejected = g.Sum(a => a.ApplicationStatusId == 3 ? 1 : 0),
            Total = g.Count()
        };
