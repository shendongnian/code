        User user = db.users.Find(1);
        // change the state to Deleted.
        foreach(var r in user.Roles)
           db.Entry(r).State = System.Data.Entity.EntityState.Deleted; 
        // Add the new roles
        user.Roles.AddRange(roles); 
