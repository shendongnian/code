    public abstract class AbstractClass
    {
       public abstract IList GetItems(); //has to be implemented later on
    }
    public abstract class AbstractClass<T>: AbstractClass
    {
        public List<T> Items { get; set; }
        public override IList GetItems() { return Items; }  //Items only visible as objects.
        public AbstractClass() 
        {
            Items = new List<T>(); //Make sure example further down is working.
        }
    }
    class ChildClass1 : AbstractClass<MyType1> { }
    class ChildClass2 : AbstractClass<MyType2> { }
