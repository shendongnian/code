    public enum NotificationType { User, Global }
    public class mytype {
    public int ID {get;set;}
    public NotificationType type {get;set;}
    public DateTime FirstDate {get;set;}
    public UserNotification un {get;set;}
    public GlobalNotification gn {get;set;}
    }
    
    var q = db.UserNotifications.Where(c => c.UserID == forUser.ScirraUserID)
        .Select(c => new mytype {c.ID, type = NotificationType.User, date = c.FirstDate, un=c, gn=null})
        .Union(db.GlobalNotifications.Select(c => new mytype {c.ID, type = NotificationType.Global, date = c.Date, un=null, gn=c }))
        .OrderBy(c => c.date)
        .Skip(skip)
        .Take(take);
