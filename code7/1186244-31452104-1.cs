    public sealed class DomainQueryFactoryQueryable<T> : IQueryable<T>
    {
        private readonly IDomainQueryFactory factory;
        public DomainQueryFactoryQueryable(IDomainQueryFactory factory) {
            this.factory = factory;
        }
        public Type ElementType { get { return this.GetQuery().ElementType; } }
        public Expression Expression { get { return this.GetQuery().Expression; } }
        public IQueryProvider Provider { get { return this.GetQuery().Provider; } }
        public IEnumerator<T> GetEnumerator() {
            return this.GetQuery().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
        private IQueryable<T> GetQuery() { 
            return this.factory.Query<T>();
        }
    }
