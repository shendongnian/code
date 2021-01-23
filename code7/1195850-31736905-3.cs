    public class DbHelper<T> where T : class
    {
        private readonly string[] _keyNames;
        public DbHelper(DbContext context)
        {
            ObjectSet<T> objectSet = ((IObjectContextAdapter)context).ObjectContext.CreateObjectSet<T>();
            _keyNames = objectSet.EntitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();
        }
        public IEnumerable<T> RetreivePages(IQueryable<T> query, int count, int pageSize)
        {
            int pages = count / pageSize;
            if (count % pageSize > 0)
            {
                pages++;
            }
            for (int i = 0; i < pages; i++)
            {
                IQueryable<T> queryToRun = _keyNames.Aggregate(query, (current, keyName) => current.OrderByField(keyName));
                foreach (T item in queryToRun.Skip(i * pageSize).Take(pageSize))
                {
                    yield return item;
                }
            }
        }
    }
