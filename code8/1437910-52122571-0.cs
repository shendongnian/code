    public interface IService
    {
        string Name { get; set; }
    }
    public class ServiceA : IService
    {
        public string Name { get { return "A"; } }
    }
    public class ServiceB : IService
    {    
        public string Name { get { return "B"; } }
    }
    public class ServiceC : IService
    {    
        public string Name { get { return "C"; } }
    }
