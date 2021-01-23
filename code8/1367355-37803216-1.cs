    public interface MyInterfaceA : IService { }
    public interface MyInterfaceB : IService { }
    public class MyServiceAB : StatelessService, MyInterfaceA, MyInterfaceB
    {
    }
