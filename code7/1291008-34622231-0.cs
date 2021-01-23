    public class Entity : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public EntityRole Role { get; set; }         
        public EntityStats Stats = new EntityStats(this);
        //Other stuff.... 
    }
    public class EntityStats : INotifyPropertyChanged
    {
        private Entity _entity;
    
        public Entity Entity
        {
            get { return _entity; }
        }
    
        public EntityStats(Entity entity)
        {
            _entity = entity;
        }
        // ...
    }
