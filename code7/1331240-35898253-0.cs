    public abstract class Foo
    {
        protected abstract CustomObject CustomObject {get; }
    
        public Foo()
        {
            // Do stuff
        }
        // Other methods that use _customObject
    }
    
    public class Bar : Foo
    {
        // Constructor and other methods
        
        protected override CustomObject CustomObject
        {
            get { return "X"; }
        }
    }
