    public interface IHasPredicateGetter<T> {
       [NotNull] Expression<Func<T, bool>> GetPredicateFromString([NotNull] string pValue);
    }
    public class Movie : IHasPredicateGetter<Movie> {
       public int ID { get; set; }
       public string Name { get; set; }
       public Expression<Func<Employee, bool>> GetPredicateFromString(string pValue) {
          return m => m.Name.Contains(pValue);
       }
    }
