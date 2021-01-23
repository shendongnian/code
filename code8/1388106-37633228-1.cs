    ...
    db.Users.Add(user);
    db.SaveChanges();
    
    for (int i = 0; i < Qualifications.Count(); i++)
    {
       var qualification = Qualifications[i];
       qualification.AssignedUser = user.id;
       db.Entry(qualification).State = EntityState.Modified;
       await db.SaveChangesAsync();
    }
