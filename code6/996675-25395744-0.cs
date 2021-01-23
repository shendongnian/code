    public List<User> GetUsersBySessions(string[] sessionStrs, string ip)
    {
        using (var ctx = new DataContext())
        {
            var ret = ctx.Sessions.Include("User");
            if(sessionStrs!=null && sessionStrs.Any())
               ret =ret.Where(s => sessionStrs.Contains(s.ID));
            if(!string.IsNullOrEmpty(ip))
               ret =ret.Where(s => s.IP.Equals(ip));
             
            return ret.Any()?ret.Select(s => s.User).ToList():NULL;
        }
    }
