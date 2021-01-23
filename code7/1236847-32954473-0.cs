    db.Users.Attach(item);
    db.Entry(item).Property(x => x.ID).IsModified = true;
    db.Entry(item).Property(x => x.name).IsModified = true;
    db.Entry(item).Property(x => x.att1).IsModified = true;
    db.Entry(item).Property(x => x.att2).IsModified = true;
    db.SaveChanges();
