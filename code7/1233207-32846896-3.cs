    var q = db.UserNotifications.Where(c => c.UserID == forUser.ScirraUserID)
        .Select(c => new mytype {c.ID, date = c.FirstDate, un=c, gn=null})
        .Union(db.GlobalNotifications.Select(c => new mytype {c.ID, date = c.Date, un=null, gn=c }))
        .OrderBy(c => c.date)
        .Skip(skip)
        .Take(take);
