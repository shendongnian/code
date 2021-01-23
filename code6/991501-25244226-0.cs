    public class Specification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Predicate { get; protected set; }
        public Func<IQueryable<T>, IOrderedQueryable<T>> Sort {get; protected set; }
    
        public Specification<T> OrderBy<TProperty>(Expression<Func<T, TProperty>> property)
        {
            var newSpecification = new Specification<T>(Predicate);
            if(Sort != null) {
                 newSpecification.Sort = items => Sort(items).ThenBy(property);
            } else {
                 newSpecification.Sort = items => items.OrderBy(property);
            }
            return newSpecification;
        }
    }
