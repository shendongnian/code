    public static void Look(LEBAEntities db, object obj) {
        var type = obj.GetType();
        var key = type.GetProperties().FirstOrDefault(p => 
            p.Name.Equals("ID", StringComparison.OrdinalIgnoreCase) 
            || p.Name.Equals(type.Name + "Id", StringComparison.OrdinalIgnoreCase)); 
        if(key == 0)
            db.Entry(obj).State = EntityState.Added;
        else
            db.Entry(obj).State = EntityState.Modified;
    }
    
