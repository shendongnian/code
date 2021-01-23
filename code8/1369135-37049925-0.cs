    public interface IBar
    {
        string barValue { get; set; }
    }
    public class Bar : IBar
    {
        string barValue { get; set; }
        
        protected Bar() : this("") { } // EF
        private Bar(string value)      // Private Constructor
        {
            barValue = value;
        }
        public static Bar Create(string value = "") // Factory
        {
            return new Bar(value);
        }
    }
    public interface IFoo
    {
        string fooValue { get; set; }
        ICollection<IBar> bars { get; set; }
    }
    public class Foo : IFoo
    {
        // Our Properties... note that private set does not interfere with EF at all, and helps encapsulate.
        public string fooValue { get; private set; }
        public virtual ICollection<IBar> bars { get; private set; }
        // Constructor for EF, protected since we probably dont want to ever use it ourselves.
        protected Foo(): this("") { }  
        // Our internal constructor, we will expose a factory for creating new instances (better control).
        private Foo(string value)
        {
            fooValue = value;
            bars = new List<IBar>();
        }
        // Our factory, great place to validate parameters, etc before even constructing the object.
        public static Foo Create(string value = "")
        {
            return new Foo(value);
        }
        
        // Methods for controling Foo's properties:
        public void SetValue(string value) { this.fooValue = value; }
        public void AddBar(IBar bar) { this.bars.Add(bar); }
        public void AddBarByValue(string barValue) { this.bars.Add(Bar.Create(barValue); }  // Leveraging Bar's factory
    } 
