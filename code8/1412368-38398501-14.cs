    public class SomeApplicationClass()
    {
        SrvClient Client;
        DispatcherTimer PingTimer;
        public SomeClass()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(
                "http://...:8000/Service/Address");
            OutpostClient = new OutpostRemoteClient(binding, endpoint);
            // pingTimer setup
        }
        // async voids are scary, make sure you handle exceptions inside this function
        public async void PingTimer_Tick()
        {
            try
            {
                await Client.Ping();
                // ping succeeded, do stuff
            }
            catch // specify exceptions here
            {
                // ping failed, do stuff
            }
        }
        public async Task DoTheLongRunningOperation()
        {
            // set busy variables here etc.
            string response = await Client.LongRunningOperation();
            // handle the response status here
        }
    }
