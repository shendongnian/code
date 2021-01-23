    using (YourContext db = new YourContext())
    {
      User u = db.User.Find(userEdit.UserUsername);
      db.Entity(u).State = System.Data.Entity.EntityState.Modified;
      u.FullName = userEdit.FullName;
      ....set the other properties here...
      db.SaveChanges();
    } 
