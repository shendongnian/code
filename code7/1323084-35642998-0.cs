    public static class qry
    {
        public static IQueryable Period(DateTime date) { return db.F_CustomerActivity.Where(p => p.Period == date); }
        public static IQueryable OperatingSystem(string system) { return db.F_CustomerActivity.Where(p => p.OperatingSystem == system); }
        public static IQueryable Application(string application) { return db.F_CustomerActivity.Where(p => p.Application == application); }
        public static IQueryable Version(string version) { return db.F_CustomerActivity.Where(p => p.Version == version); }
        public static IQueryable CustomerID(int id) { return db.F_CustomerActivity.Where(p => p.CustomerID == id); }
        public static IQueryable add(this IQueryable qry, Func<IQueryable> func)
        {
            var callback = func();
            return callback;
        }
