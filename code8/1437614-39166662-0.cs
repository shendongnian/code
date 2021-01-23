    public class Foo : Bar
    {
        public List<int> FooList
        {
            get;
            private set;
        }
        public Foo()
          : base()
        {
            Init();
        }
        private void Init() { this.FooList = new List<int>(); }
        public Foo(XmlNode node)
          : base(node)
        {
            Init();
            //create from enhanced xml
        }
    }
