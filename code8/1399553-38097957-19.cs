    public partial class TestDB
    {
        public static ICollection<Expression> Includes { get; set; } = new List<Expression>();
        public TestDB() : base()
        {
            Includes = new List<Expression>();
        }
        ...
    }
    public static class EntityExtensions
    {
        public static IQueryable<T> CustomInclude<T, TProperty>(this IQueryable<T> query, 
            Expression<Func<T,TProperty>> include) where T : class
        {
            TestDB.Includes.Add(include);
            return query.Include(include);
        }
    }
