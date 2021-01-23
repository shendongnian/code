    public interface MyInterfaceA : IService { }
    public interface MyInterfaceB : IService { }
    public interface MyInterfaceC : MyInterfaceA, MyInterfaaceB { }
    public class MyServiceC : StatelessService, MyInterfaceC
    {
    }
