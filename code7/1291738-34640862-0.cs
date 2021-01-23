    using System.Data.Entity;
    using System.Linq;
    
    namespace Stackoverflow
    {
        public static class EntityExtensions
        {
            public static IQueryable<Item> IncludePrimaryNode(this IQueryable<Item> query)
            {
                // eager loading if this extension method is used
                return query.Include(item => item.PrimaryNode);
            }
    
            public static IQueryable<Item> IncludeUser(this IQueryable<Item> query)
            {
                // eager loading if this extension method is used
                return query.Include(item => item.User);
            }
        }
    }
