    public interface IMyInterface
    {
        String Name { get; set; }
    }
    
    public class MyIntImpl : IMyInterface
    {
        public String Name { get; set; }
    }
    
    public class MyClass
    {
        public IMyInterface IntRef { get; set; }
    
        public MyClass()
        {
            IntRef = new MyIntImpl();
        }
    }
    
    // When starting up MongoDB
    private void RegisterClasses()
    {
        BsonClassMap.RegisterClassMap<MyIntImpl>();
    }
