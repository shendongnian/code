    public static class EntityFrameworkExtension
    {
        public static void AddIfNotExists<T>(
            this IDbSet<T> t, Func<T, object> func, params T[] objectsToAdd) 
            where T : class
        {
            foreach (var obj in objectsToAdd
                .Where(obj => !t.Select(func).Contains(func.Invoke(obj))))
                    t.Add(obj);
        }
    }
