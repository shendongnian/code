    public void AddXp(int xp, ApplicationUser user)
    {
         user.Xp += xp;
         // Mark the entity as modified
         db.Entry(user).State = EntityState.Modified;
    
         db.SaveChanges();
    }
