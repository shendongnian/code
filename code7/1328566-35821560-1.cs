    public class Foo
    {
        public List<String> FooList { get; private set; }
    
        public Foo()
        {
            FooList = new List<string>();
        }
    
        public void OperationsOnFoo()
        {
            //Some stuff who's going to add data to FooList
        }
    }
    
    public class Foo2 : Foo
    {
        public void Foo2Methods()
        {
            //Have fun getting the data here!
        }
    }
