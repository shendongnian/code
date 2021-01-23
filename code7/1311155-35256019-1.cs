    public class CommonService<T> : ICommonService<T> where T : BaseEntity
    {
        private readonly IRepository<T> repository;
        public CommonService(IRepository<T> repository)
        {  
            if (repository == null) throw new ArgumentNullException(nameof(repository)); 
            this.repository = repository;
        }
        // and other methods
    }
