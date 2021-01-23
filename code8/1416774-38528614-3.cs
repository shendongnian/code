    using (var db = new MyEF6Entities()) {
        var recentUserList = db.Users.Where(u => u.IsOnline)
                                     .FromCache(DateTime.Now.AddHours(1), "recent");
    								 
        var onlineUserList = db.Users.Where(u => u.IsOnline)
                                     .FromCache(DateTime.Now.AddSeconds(30), "online");
    }
