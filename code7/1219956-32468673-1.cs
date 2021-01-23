    class BaseT
    { }
    
    class DerivedA : BaseT
    { }
    
    class DerivedB : BaseT
    { }
    
    class Generator
    {
        public string Generate(IEnumerable<BaseT> objects)
        {
            string str = "";
            dynamic generator = this;
            foreach (dynamic item in objects)
            {
                str = str + generator.Generate(item); 
            }
            return str;
        }
    
        protected internal virtual string Generate(DerivedA a)
        {
            return " A ";
        }
    }
    
    class DerivedGenertor : Generator
    {
        protected internal virtual string Generate(DerivedB b)
        {
            return " B ";
        }
    }
    
    
    
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseT> items = new List<BaseT>() { new DerivedA(), new DerivedB() };
            var generator = new DerivedGenertor();
            string ret = generator.Generate(items);
        }
    }
