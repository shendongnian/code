    using System.Linq.Expressions;
        public class ContextWithExtensionExample
        {
            public void DoSomeContextWork(DbContext context)
            {
                var uni = new Unicorn();
                context.Set<Unicorn>().AddIfNotExists(uni , x => x.Name == "James");
            }
        }
    
        public static class DbSetExtensions
        {
            public static T AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class, new()
            {
                var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();
                return !exists ? dbSet.Add(entity) : null;
            }
        }
