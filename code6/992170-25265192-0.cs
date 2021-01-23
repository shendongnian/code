    public static class MyLibrary
    {
        public static void Add<T>(this DbContext db, T obj) where T : class
        {
            db.Set<T>().Add(obj);
        }
    }
