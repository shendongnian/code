    public class Specification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>> Predicate { get; protected set; }
        public Func<IQueryable<T>, IOrderedQueryable<T>> Sort {get; protected set; }
        public Func<IQueryable<T>, IQueryable<T>> PostProcess {get; protected set;
    
        public Specification<T> OrderBy<TProperty>(Expression<Func<T, TProperty>> property)
        {
            var newSpecification = new Specification<T>(Predicate) { PostProcess =  ;
            if(Sort != null) {
                 newSpecification.Sort = items => Sort(items).ThenBy(property);
            } else {
                 newSpecification.Sort = items => items.OrderBy(property);
            }
            return newSpecification;
        }
        public Specification<T> Take(int amount)
        {
            var newSpecification = new Specification<T>(Predicate) { Sort = Sort } ;
            if(PostProcess!= null) {
                 newSpecification.PostProcess= items => PostProcess(items).Take(amount);
            } else {
                 newSpecification.PostProcess= items => items.Take(amount);
            }
            return newSpecification;
        }
        public Specification<T> Skip(int amount)
        {
            var newSpecification = new Specification<T>(Predicate) { Sort = Sort } ;
            if(PostProcess!= null) {
                 newSpecification.PostProcess= items => PostProcess(items).Skip(amount);
            } else {
                 newSpecification.PostProcess= items => items.Skip(amount);
            }
            return newSpecification;
        }
    }
