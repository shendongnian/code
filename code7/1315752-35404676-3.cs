    public ActionResult EditUser(string userId)
    {
        using (ApplicationDbContext context = new ApplicationDbContext())
        {
            var user = context.Users.Find(userId);
            user.Name = "Edited Name";
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
