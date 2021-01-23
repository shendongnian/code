    using (var db = new MyEF6Entities()) {
        var path = db.Configuration.Where(c => c.name="Path")
                                   .FromCache(DateTime.Now.AddMinutes(60));
    
        var onlineUserList = db.Users.Where(u => u.IsOnline)
                                     .FromCache(DateTime.Now.AddSeconds(30));
    }
