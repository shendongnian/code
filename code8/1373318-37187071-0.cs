    public class ServiceClient : IServiceClient
    {
        private HttpClient m_Client;        
        public ServiceClient
        {
             m_Client = new HttpClient();
             // Initialize the client as you need here
        }
        
        public void CallSomeMethod()
        {
            // Call method on the client
        }
    }
