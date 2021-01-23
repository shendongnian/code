    public class GenericJobLogic<T> where T : IJob
    {
        private Repository<T> engine;
        public GenericJobLogic()
        {
            this.engine = unitOfWork.Repository<T>();
        }
        public virtual T Get(long id)
        {
            return this.engine.Get(id);
        }
    }
