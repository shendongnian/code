     public static class StaticCache<T>  where T: class 
     {
        private static List<T> dbSet;
        public static Dictionary<string, List<T>> cache = new Dictionary<string, List<T>>();
        private static readonly object Lock = new object();
        public static void Load(DbContext db, string connStr, string tableName)
        {
            lock (Lock)
            {
                try
                {
                    if (connStr != null)
                    {
                        using (db)
                        {
                            dbSet = db.Set<T>().ToList();                            
                            cache.Add(tableName, dbSet);
                        }
                    }
                }
                catch { }
            }
        }
     }
     void Testit() 
     {
        var context = new YourContextSubClass(connStr);       
        StaticCache<TableEntity>.Load(context, connstr, "tableEntityNameString");
     }
