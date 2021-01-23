    public abstract class EntityCollection<EntityType, T> where EntityType : Entity<T>
        {
            public abstract EntityType Get(T id);
            public abstract void Add(EntityType entity);
            public abstract IEnumerable<EntityType> GetAll();
        }
