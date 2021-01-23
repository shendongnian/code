    public abstract class Model<TEntity> : IEntity 
                where TEntity : IEntity
    {
        public IMyInterface<TEntity> DataService { get; set; }
    }
