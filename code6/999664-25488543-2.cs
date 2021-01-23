    public abstract class AbstractClass
    {
       public abstract void MethodOnAbstractClass();
    }
    
    public abstract class AbstractClass<T>: AbstractClass
    {
        public abstract List<T> Items { get; set; }
    }
