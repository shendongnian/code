    class Component
    {
        public Entity Owner { get; protected set; }
    }
    class Component<T> : Component where T : Entity
    {
        new public T Owner
        {
            get { return (T)base.Owner; }
            set { base.Owner = value; }
        }
    }
