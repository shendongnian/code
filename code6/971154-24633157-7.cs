    public class MyPipeClient : IMyService, IDisposable
    {
        ChannelFactory<IMyService> myServiceFactory;
        
        public MyPipeClient()
        {
            //This is likely where your culprit will be.
            myServiceFactory = new ChannelFactory<IMyService>(new NetNamedPipeBinding(), new EndpointAddress(Constants.myPipeService + @"/" + Constants.myPipeServiceName));
        }
        public String Hello(String Name)
        {
            //But this is where you will get the exception
            return myServiceFactory.CreateChannel().Hello(Name);
        }
        public Person GetPerson()
        {
            return myServiceFactory.CreateChannel().GetPerson();
        }
        public void Dispose()
        {
            ((IDisposable)myServiceFactory).Dispose();
        }
    }
