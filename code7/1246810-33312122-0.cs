     public class GenericLogic<T> where T : BaseEntity
    {
        private Repository<T> engine;
        private UnitOfWork unitOfWork = new UnitOfWork();
        public T Entity;
        public GenericLogic()
        {
            this.engine = unitOfWork.Repository<T>();
        }        
        #region CRUD
        public void Add()
        {
            engine.Add(Entity);
        }
        public T Get(long id)
        {}
        public void Edit()
        {}
       public void Delete()
        {}
        public List<T> List()
        {}
        #endregion
    }
