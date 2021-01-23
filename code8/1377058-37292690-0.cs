    public T GetItemByQuery<T>(Expression<Func<T, bool>> query, params string[] NavigationProperties) where T : EntityObject
    {
        using (Entities context = new Entities())
        {
            var ObjectSet = context.CreateObjectSet<T>().AsQueryable();
            foreach (string prop in NavigationProperties)
            {
                ObjectSet = ObjectSet.Include(prop);
            }
            return ObjectSet.Where(query).FirstOrDefault();
        }
    }
