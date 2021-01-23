    DBContext db = new DBContext(dbConnString);
    db.Database.CreateIfNotExists();
    PropertyInfo[] properties = typeof(Foos).GetProperties();
    foreach (var prop in properties)
    {
        process(prop.Name);
    }
