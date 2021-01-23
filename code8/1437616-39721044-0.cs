    public abstract class Bar
    {
        public List<string> BarList { get; private set; }
        public Bar()
            : this(null)
        { }
        public Bar(XmlNode node)
        {
            this.BarList = new List<string>();
            if (node == null)
                return;
            //create from xml
        }
    }
    public class Foo : Bar
    {
        public List<int> FooList { get; private set; }
        public Foo()
            : this(null)
        { }
        public Foo(XmlNode node)
            : base(node)
        {
            this.FooList = new List<int>();
            if (node == null)
                return;
            //create from enhanced xml
        }
    }
