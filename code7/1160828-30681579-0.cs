    public static void Create<T>(this DbContext db, T entityToCreate)
        where T : class
    {
        db.Set<T>().Add(entityToCreate);
        db.SaveChanges();
    }
