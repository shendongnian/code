    public void AddXp(int xp, ApplicationUser user)
    {
        user.Xp += xp;
        db.Entry(user).State = EntityState.Modified;
        db.SaveChanges();
    }
