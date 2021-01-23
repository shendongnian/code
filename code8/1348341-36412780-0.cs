    public class ClientConnectionService : ConnectionModelBase
    {
        private static readonly ClientConnectionService instance 
        = new ClientConnectionService();
        private ClientConnectionService() { }
        public static ClientConnectionService getClientConnectionService()
        {
            return instance;
        }
        public string Connect(string ipAddress, int portNumber)
        {
            //Some code
        }
        //More code below, just omitted.
    }
