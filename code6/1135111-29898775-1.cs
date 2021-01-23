    public abstract class SectionWorkerServices<T,TDomainModel> : ISectionWorkerServices<T> where T :SectionInputModelBase
    {
        private readonly IRepository<TDomainModel> _repository; // a T for its domain model
    
        protected SectionWorkerServices()
        {
            _repository = CreateRepository();
        }
    
        public bool HasSection(Guid id)
        {
            var entity = _repository.Find(id);
            var hasSection = entity != null;
            if (hasSection) _repository.Detach(entity);
            return hasSection;
        }
        ....
        public abstract void Update(T  model, SectionStatus status);
        //Factory Method
        public abstract IRepository<TDomainModel> CreateRepository();
    }
