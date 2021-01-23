    public abstract class ContentReference
    {
        public string Name { get; private set; }
    
        protected ContentReference(string name)
        {
            Name = name;
        }
        public abstract void Play();
    }
    
    public class ContentReference<T> where T : IReferable
    {
        public ContentReference(T value) : base(value.Name)
        {
        }        
    
        public static implicit operator ContentReference<T>(T value)
        {
            return new ContentReference<T>(value);
        }
        public override void Play()
        {
            // Play the IReference 
        }
    }
