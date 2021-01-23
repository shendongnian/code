    public class FactoryClass
    {
       public IMyInterface CreateInstance()
       {
           return new MyInternalClass(); 
       }
    }
    
    internal class MyInternalClass : IMyInterface
    {
    }
