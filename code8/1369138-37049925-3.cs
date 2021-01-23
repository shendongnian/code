    public interface IBar
    {
        string barValue { get; }        // Values can sometimes be valuable in interfaces, see Foo's AddBar behavior.
        void SetValue(string value); // Interfaces work best describing behavior, not structure.
    }
    public class Bar : IBar
    {
        public string barValue { get; private set; }
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
        void SetValue(string value);
        void AddBar(IBar bar);
    }
    public class Foo : IFoo
    {
        // Our Properties... note that private set does not interfere with EF at all, and helps encapsulate.
        public string fooValue { get; private set; }
        public virtual ICollection<Bar> bars { get; private set; }
        // Constructor for EF, protected since we probably dont want to ever use it ourselves.
        protected Foo() : this("") { }
        // Our internal constructor, we will expose a factory for creating new instances (better control).
        private Foo(string value)
        {
            fooValue = value;
            bars = new List<Bar>();
        }
        // Our factory, great place to validate parameters, etc before even constructing the object.
        public static Foo Create(string value = "")
        {
            return new Foo(value);
        }
        // Methods for controling Foo's properties:
        public void SetValue(string value) { this.fooValue = value; }
        public void AddBar(IBar bar) { this.bars.Add(Bar.Create(bar.value)); }  // Leveraging Bar's factory
    } 
