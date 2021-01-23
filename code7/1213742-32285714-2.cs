    public static class UpdateHelper
    {
        // where ObjectContext is the base class for 'StaticDataEntities' that contains ObjectContext.SaveChanges();
        public static int Update<T>(Action<T> action) where T : ObjectContext, new()
        {
            var entities = new T();
            action(entities);
            return entities.SaveChanges();
        }
    }
