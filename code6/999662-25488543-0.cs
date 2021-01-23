    public class AbstractClass
    {
       public void MethodOnAbstractClass();
    }
    
    public abstract class AbstractClass<T>: AbstractClass
    {
        public abstract List<T> Items { get; set; }
    }
