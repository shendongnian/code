    public class MyPipeClient : IMyService, IDisposable
    {   
        //Sub IMyService with your service interface contract
        ChannelFactory<IMyService> myServiceFactory;
        
        public MyPipeClient()
        {
            // Sub NetNamedPipeBinding with your bindings.
            myServiceFactory = new ChannelFactory<IMyService>(new NetNamedPipeBinding(), new EndpointAddress(Constants.myPipeService + @"/" + Constants.myPipeServiceName) );
       
        }
        //Implementation Details no one cares about would go here
        //...
        //Example where Hello is one of the functions from my Service.
        public String Hello(String Name)
        {
            return Channel.Hello(Name);
        }
        public IMyService Channel
        {
            get
            {
                return myServiceFactory.CreateChannel();
            }
        }
    }
