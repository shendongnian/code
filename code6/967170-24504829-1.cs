    internal static class MyExtensions
    {
        public static IOrderedQueryable<TSource> OrderBy<TSource, TField>(this IQueryable<TSource> source, Expression<Func<TSource, TField>> selector, bool descending)
        {
            return descending 
                ? source.OrderByDescending(selector)
                : source.OrderBy(selector);
        }
    }
    var orderers = new List<Func<IQueryable<Products>, IOrderedQueryable<Products>>>()
        {
            source => source.OrderBy(x => x.Id, true),
            source => source.OrderBy(x => x.Id, false), 
            source => source.OrderBy(x => x.Name, false)
        };
    // To be replaced with entity source-collection.
    IQueryable<Products> dummySource = new EnumerableQuery<MyType>(new List<Products>());
    orderers[0](dummySource.Where(x => x.Id != 0));
