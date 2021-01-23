    public abstract class BaseAbstractClass : ISomeInterface<EntityA, EntityB>
    {
        protected abstract EntityA SomeMethodImpl(EntityB entityB);
        public EntityA SomeMethod(EntityB entityB) 
        {
            return SomeMethodImpl(entityB);
        }
    }
