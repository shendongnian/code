    static void Main(string[] args)
        {               
            ServiceHost serviceHost;
            serviceHost = new ServiceHost(typeof(PCsService));
            try
            {
                serviceHost.Open();
                ...
                ...
