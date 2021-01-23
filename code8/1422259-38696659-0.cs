    public interface ITest
    {
    
     // your interface method and properties
    }
    
    public class Child : ITest
    {
     // do your stuff here
    }
    
    public abstract class MyClass
    {
        public MyClass(ITest tes)
        {
        // do stuff using test
        }
    }
