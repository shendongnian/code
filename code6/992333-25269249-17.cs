    class Program
    {
        static void Main(string[] args)
        {
            Composite root = new Composite("Root");
            Composite branch1 = new Composite("Branch1");
            branch1.Add(new ConcreteElement("Leaf1", "Bar"));
            branch1.Add(new ConcreteElement("Leaf2", "Baz"));
            root.Add(branch1);
            Composite branch2 = new Composite("Branch2");
            branch2.Add(new ConcreteElement("Leaf3", "Quux"));
            Composite branch3 = new Composite("Branch3");
            branch3.Add(new ConcreteElement("Leaf4", "Fizz"));
            branch2.Add(branch3);
            root.Add(branch2);
            string json = JsonConvert.SerializeObject(root, Formatting.Indented, new CompositeConverter());
            Console.WriteLine(json);
        }
    }
    public abstract class Element
    {
        protected string _name;
        public Element(string name)
        {
            _name = name;
        }
        public abstract void Add(Element element);
        public string Name { get { return _name; } }
    }
    public class ConcreteElement : Element
    {
        public ConcreteElement(string name, string foo) : base(name)
        {
            Foo = foo;
        }
        public string Foo { get; set; }
        public override void Add(Element element)
        {
            throw new InvalidOperationException("ConcreteElements may not contain Child nodes. Perhaps you intended to add this to a Composite");
        }
    }
    public class Composite : Element
    {
        public Composite(string name) : base(name) { Elements = new List<Element>(); }
        private List<Element> Elements { get; set; }
        public override void Add(Element element)
        {
            Elements.Add(element);
        }
    }
