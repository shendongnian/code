    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        string SayHello(string name);
    }
    public class HelloWorldService : IHelloWorldService
    {
        private IHelloWorld helloWorld = new HelloWorld();
  
        public string SayHello(string name)
        {
            return helloWorld.SayHello(name);
        }
    }
