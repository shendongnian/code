    public abstract class SectionWorkerServices<T> : ISectionWorkerServices<T> where T :SectionInputModelBase
    {
        protected SectionWorkerServices()
        {
        }
    
        public bool HasSection(Guid id)
        {
            var entity = Repository.Find(id);
            var hasSection = entity != null;
            if (hasSection) Repository.Detach(entity);
            return hasSection;
        }
        ....
        public abstract void Update(T  model, SectionStatus status);
        protected abstract IRepository<T> Repository { get; }
    }
