    using (MyEntities db = new MyEntities())
    {
        var result = db.GetUsere();
        var result1 = db.GetUserRoles();
        ...
    }
