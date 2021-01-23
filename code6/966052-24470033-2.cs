    public class Service1 : IHelloWorld
    {
        
        public HelloWorldResponse Hello(HelloWorldAsk request)
        {
            return new HelloWorldResponse
            {
                YourId = request.MyEmail,
                YourName = request.MyName
            };
        }
    }
