    public interface IServiceA
    {
       bool IsVisible();
    }
    public interface IServiceB
    {
       void SetValue();
    }
    public class SomeClass : IServiceA, IServiceB
    {
       public bool IsVisible(){}
       public void SetValue(){}
    }
