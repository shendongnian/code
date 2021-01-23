    public class QueryRunner : IRunQuery
    {
        private readonly ISession session;
        public QueryRunner(ISession session)
        {
            this.session = session;
        }
        public IEnumerable<T> Run<T>(IQuery<T> query) where T : EntityBase<T>
        {
            return query.Run(session.Query<T>());
        }
    }
