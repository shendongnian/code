    public interface IQuerySpec<M> { }
    public class OrderedSortation<T> {}
    public static class IQuerySpecExtensions
    {
        public static OrderedSortation<T> OrderBy<T, TKey>(this T query, System.Linq.Expressions.Expression<Func<T, TKey>> sort) where T : IQuerySpec<TKey>
        {
            throw new NotImplementedException(); // business as usual
        }
    }
    public class Foo : IQuerySpec<int>, IQuerySpec<string>
    {
        public int SizeOfSailBoat {get; set;}
        public string NameOfSailBoat {get; set;}
    }
