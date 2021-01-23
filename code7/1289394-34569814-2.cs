    public abstract class BaseClass
    {
        protected BaseClass()
        {
            UniqueIdentifier = Guid.NewGuid();
        }
    
        public Guid UniqueIdentifier { get; set; }
    }
