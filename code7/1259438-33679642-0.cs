    using System;
    // ... other 3rd party usings
    
    namespace MyExtensionsNamespace
    {
        public static class MyExtensions
        {
            public static IQueryable<T> Where<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate)
            {
                throw new SecurityException("Use the security SafeWhere method");
            }
            // ...
        }
    }
