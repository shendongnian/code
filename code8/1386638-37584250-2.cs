    public interface IServiceA
    {
       bool IsVisible();
    }
    public interface IServiceB
    {
       void SetValue();
    }
    public class ServiceA : IServiceA
    {
       public bool IsVisible(){}
    }
    public class ServiceB : IServiceB
    {
       public void SetValue(){}
    }
    public class SomeClass : IServiceA, IServiceB
    {
       private IServiceA _a;
       private IServiceB _b;
       
       public SomeClass(IServiceA a, IServiceB b)
       {
          _a = a;
          _b = b;
       }
    
       public bool IsVisible()
       {
         _a.IsVisible(); // if you want to re-use
       }
       public void SetValue()
       {
          // implement some logic here if you want to 'override'
       }
    }
