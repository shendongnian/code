    // Simple interface defining the "service."
    public interface IService { }
    
    // Four different services - one for each
    // combination of application and business state
    // (e.g., ApplicationState=true, BusinessState=false).
    public class FirstService : IService { }
    public class SecondService : IService { }
    public class ThirdService : IService { }
    public class FourthService : IService { }
