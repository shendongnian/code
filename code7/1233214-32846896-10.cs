    var q1 = db.UserNotifications
        .Where(c => c.UserID == forUser.ScirraUserID)
        .OrderBy(c => c.FirstDate)
        .Select(c => new mytype {
            c.ID, 
            type = NotificationType.User, 
            date = c.FirstDate, 
            un=c, 
            gn=null})
        .Take(skip+take)
        .ToList();
    var q2=db.GlobalNotifications
        .OrderBy(c => c.Date)
        .Select(c => new mytype {
            c.ID, 
            type = NotificationType.Global, 
            date = c.Date, 
            un=null, 
            gn=c })
        .Take(skip+take)
        .ToList();
    var r=q1.Concat(q2)
        .OrderBy(c => c.FirstDate)
        .Skip(skip)
        .Take(take);
