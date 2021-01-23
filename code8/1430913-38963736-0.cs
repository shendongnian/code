    public interface IService<IResult>
    {
        IResult DoWork();
    }
    
    public class ServiceA<IResult> : IService<IResult> {}
    
    
    public interface IFactory
    {
        IResult GetService(string documentType);
    }
