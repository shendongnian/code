    public class Entity
    {
        private readonly ISubEntityFactory _subEntityFactory; 
        public Entity(ISubEntityFactory subEntityFactory) {
            _subEntityFactory = subEntityFactory;
        }
        public void Process(int someData, Status initialStatus)
        {
            if (SomeConditionIsMet)
            {
                SubEntity = _subEntityFactory.Create(this, initialStatus);
            }
        }
    }
