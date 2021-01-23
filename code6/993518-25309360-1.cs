    public struct GetHelper<TId>
    {
        private readonly Repository _repository;
        private readonly TId _id;
        internal GetHelper(Repository repository, TId id)
        {
            _repository = repository;
            _id = id;
        }
        public T Get<T>() where T : IEntity<TId>
        {
            return _repository.Get<T, TId>(_id);
        }
    }
