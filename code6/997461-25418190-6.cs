        db.Entry(newContact).State = EntityState.Modified;
        var p1 = new Person { Id = 1 };
        db.Entry(p1).State = EntityState.Unchanged;
        var p3 = new Person { Id = 3 };
        db.Entry(p3).State = EntityState.Unchanged;
        var manager = ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager;
        manager.ChangeRelationshipState(newContact, p1, item => item.ContactOwner,
             EntityState.Deleted);
        manager.ChangeRelationshipState(newContact, p3, item => item.ContactOwner,
             EntityState.Added);
        db.SaveChanges();
