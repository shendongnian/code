    var q = db.UserNotifications
        .Where(c => c.UserID == forUser.ScirraUserID)
        .ToList()
        .Select(c => new mytype {
            c.ID, 
            type = NotificationType.User, 
            date = c.FirstDate, 
            un=c, 
            gn=null})
        .Concat(
            db.GlobalNotifications
                .Select(c => new mytype {
                    c.ID, 
                    type = NotificationType.Global, 
                    date = c.Date, 
                    un=null, 
                    gn=c })
                .ToList())
        .OrderBy(c => c.date)
        .Skip(skip)
        .Take(take);
