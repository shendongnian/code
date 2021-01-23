    public class Entity1View1
    {
        protected Entity1 wrapped;
        public Entity1View1(Entity1 entity)
        {
            wrapped = entity;
        }
        public String Property1
        {
            get { return wrapped.Property1; }
        }
        public String Property2
        {
            get { return wrapped.Property2; }
        }
        public String Property3
        {
            get { return wrapped.Property3.ToUpper(); }
        }
    }
