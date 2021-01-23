    public class MyClassBase 
    {
    
    }
    public class MyClass<T> : MyClassBase
        where T : IMyInterface
    {
        public List<T> list = new List<T>();
    }
