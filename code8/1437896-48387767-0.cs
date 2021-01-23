    public interface IService 
    {
    }
    
    public interface IServiceA: IService
    {}
    public interface IServiceB: IService
    {}
    public IServiceC: IService
    {}
    public class ServiceA: IServiceA 
    {}
    public class ServiceB: IServiceB
    {}
    public class ServiceC: IServiceC
    {}
