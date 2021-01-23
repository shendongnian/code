    public struct GetHelper<T>
    {
        internal readonly Repository Repository;
        public GetHelper(Repository repository)
        {
            Repository = repository;
        }
    }
    public static class RepositoryExtensions
    {
        public static T ById<T, TId>(this GetHelper<T> helper, TId id)
          where T : IEntity<TId>
        {
            return helper.Repository.Get<T, TId>(id);
        }
    }
