    public static IQueryable<T> JoinQueries<T>
    (this IQueryable<T> query, IQueryable<T> expr) where T : IHasId
    {
        if (query == null)
            throw new ArgumentNullException("query");
        //Here we make Join for x and and return result something like this:
        query = from a in query join b in expr on a.Id equals b.Id select a;
        return query;
    }
    public interface IHasId
    {
        int Id { get; set; }
    }
