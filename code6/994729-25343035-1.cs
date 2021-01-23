    db.Entry(user).State = EntityState.Modified;
    foreach(Brand b in user.Brands)
    {
        db.Entry(b).State = System.Data.Entity.EntityState.Modified;
        (IObjectContextAdapter)db).ObjectContext.ObjectStateManager
           .ChangeRelationshipState(user, b, u => u.Brands, EntityState.Added);
    }
    db.SaveChanges();
