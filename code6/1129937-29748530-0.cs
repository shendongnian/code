     public class Persister<TContract, TEntity> : IPersister<TContract, TEntity> where TEntity : class,IDeletableEntity
    {
        public Persister(IDeletableEntityRepository<TEntity> repository)
        {
            this.repository = repository;
        }
        public void Add(TContract model)
        {
            var entity = Mapper.Map<TContract, TEntity>(model);
            repository.Add(entity);
            repository.SaveChanges();
        }
        public IQueryable<TContract> All<TContract>()
        {
            return repository.All().Where(x => !x.IsDeleted).Project().To<TContract>();
        }
        #region Private Members
        private IDeletableEntityRepository<TEntity> repository;
        #endregion
    }
