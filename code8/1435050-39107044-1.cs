    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly ISession _session;
        #region constructor
        public Repository(ISession session)
        {
            _session = session;
        }
        #endregion
        #region Transact
        protected virtual TResult Transact<TResult>(Func<TResult> func)
        {
            if (_session.Transaction.IsActive)
                return func.Invoke();
            TResult result;
            using (var tx = _session.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                result = func.Invoke();
                tx.Commit();
            }
            return result;
        }
        protected virtual void Transact(System.Action action)
        {
            Transact(() =>
            {
                action.Invoke();
                return false;
            });
        }
        #endregion
        #region IRepository<T> Members
        public void Save(T item)
        {
            Transact(() => _session.Save(item));
        }
        public Boolean Contains(T item)
        {
            if (item.Id == default(Guid))
                return false;
            return Transact(() => _session.Get<T>(item.Id)) != null;
        }
        public Int32 Count
        {
            get
            {
                return Transact(() => _session.Query<T>().Count());
            }
        }
        public bool Remove(T item)
        {
            Transact(() => _session.Delete(item));
            return true;
        }
        public T Load(Guid id)
        {
            return Transact(() => _session.Load<T>(id));
        }
        public T Get(Guid id)
        {
            return Transact(() => _session.Get<T>(id));
        }
        public IQueryable<T> FindAll()
        {
            return Transact(() => _session.Query<T>());
        }
        #endregion
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return Transact(() => _session.Query<T>().Take(1000).GetEnumerator());
        }
        #endregion
        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Transact(() => GetEnumerator());
        }
        #endregion
    }
