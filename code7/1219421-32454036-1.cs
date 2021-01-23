    // This car accepts any engine that implements IEngine
    public class Car 
    {
         public IEngine Engine { get; set; }
    }
    public interface IEngine 
    {
         void Start();
    }
