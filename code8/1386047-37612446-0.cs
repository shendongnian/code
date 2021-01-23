    using (var con = new ApplicationDbContext())
    {
        string userId = Context.User.Identity.GetUserId<string>();
        var userR = con.Users.FirstOrDefault(x => x.Id == userId);
        userR.Wins = 0;
        userR.Loses = 0;
        userR.Ties = 0;
        con.SaveChanges();
    }
