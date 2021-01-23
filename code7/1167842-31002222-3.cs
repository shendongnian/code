    public class Entity1View2 : Entity1View1
    {
        pulic Entity1View2(Entity1 entity) : base(entity) { }
        public long? SubEntityID
        {
            get { return wrapped.SubEntity.ID; }
        }
    }
