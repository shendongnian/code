    var userDb = db.Users.Find(user.Id);
    // Updates scalar properties.
    db.Entry(userDb).CurrentValues.SetValues(user);
    foreach(Brand b in user.Brands)
    {
        // Is still required to prevent EF adds new brand.
        db.Entry(b).State = EntityState.Modified;
        userDb.Brands.Add(b);
    }
    db.SaveChanges();
