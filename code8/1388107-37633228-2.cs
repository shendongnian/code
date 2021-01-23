    ...
    db.Users.Add(user);
    db.SaveChanges();
    qualification.AssignedUser = user.Id;
    db.Entry(qualification).State = EntityState.Modified;
    await db.SaveChangesAsync();
