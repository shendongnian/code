    public List<Users> SearchUsers(string userName, int? userId)
    {
        using (var ctx = new MyEntities())
        {
            var query = ctx.User;
    
            if (userName != null)
                query = query.Where(u=>u.Name.Contains(userName));
    
            if (userId != null)
                query = query.Where(u=>u.ID==userId.Value);
    
            var users = query
                .OrderByDescending(u => u.ID)
                .ToList();
            return users;
        }
    }
