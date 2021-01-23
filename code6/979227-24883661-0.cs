    public interface IHazDateAdded {
       DateTime DateAdded {get;}
    }
    // extend the types (fortunately we can do this in partial classes)
    public partial class Foo : IHazDateAdded {}
    public partial class Bar : IHazDateAdded {}
    private static IQueryable<T> GetToday<T>(this IQueryable<T> source)
        where T : IHazDateAdded
    {
        return source.Where(
             p => DbFunctions.TruncateTime(p.DateAdded) == DateTime.Today);
    }
