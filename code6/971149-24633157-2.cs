    public class MyPipeClient : IMyService, IDisposable
    {
        ChannelFactory<IMyService> myServiceFactory;
        
        public MyPipeClient()
        {
            myServiceFactory = new ChannelFactory<IMyService>(new NetNamedPipeBinding(), new EndpointAddress(Constants.myPipeService + @"/" + Constants.myPipeServiceName + 2) );
        }
        public String Hello(String Name)
        {
            try 
            {
                return Channel.Hello(Name);
            }
            catch
            {
                return String.Empty;
            }
        }
        public Person GetPerson()
        {
            try 
            { 
                return Channel.GetPerson();
            }
            catch
            {
                return null;
            }
        }
        public Task<Person> GetPersonAsync()
        {
            return new Task<Person>(()=> GetPerson());
        }
        public Task<String> HelloAsync(String Name)
        {
            return new Task<String>(()=> Hello(Name));
        }
        public void Dispose()
        {
            myServiceFactory.Close();
        }
        public IMyService Channel
        {
            get
            {
                return myServiceFactory.CreateChannel();
            }
        }
    }
