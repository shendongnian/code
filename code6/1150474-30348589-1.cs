    public class MyClass<T,K>
        where T : Entity<K>
        where K : IEquatable<K>
    {
        public virtual bool MyMethod(T entity1, T entity2)
        {
            return entity1.EntityId.Equals(entity2.EntityId);
        }
    }
