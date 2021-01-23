    public static class StoreScopedEntity
    {
        public static Expression<Func<T, bool>> IdPredicate<T>(int id)
            where T : IStoreScopedEntity
        {
            return e => e.Stores.Select(s => s.Id).Contains(id); 
        } 
    }
