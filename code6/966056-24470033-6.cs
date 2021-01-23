    public class Service1 : IHelloWorld
    {
        
        public HelloWorldResponse Hello(HelloWorldAsk request)
        {
            //Do what you need to do - e.g. verify then save to db
            return new HelloWorldResponse
            {
                YourId = request.MyEmail,
                YourName = request.MyName
            };
        }
    }
