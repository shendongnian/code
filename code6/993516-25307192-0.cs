    public static class Extensions
    {
        public static T Get<T>()
        {
            // fake implementation, but T is required at compile time
            var result = Activator.CreateInstance<T>();
            return result;
        }
        public static T AssignId<T, U>(this T entity, U id)
            where T : IEntity<U>
        {
            entity.Id = id;
            return entity;
        }
    }
