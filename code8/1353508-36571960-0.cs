        public class MyClass
        {
            public string P1 { get; set; }
        }
    
        public static class QueryableExtensions
        {
            public static IQueryable<T> MyFilter<T>(this IQueryable<T> queryable, string value) where T : MyClass
            {
                return queryable.Where(arg => arg.P1 == value);
            } 
        }
