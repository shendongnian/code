    public static void DynamicAddress(
    {
        int sessionIdentification = 0;
        int portNumber = 0;
        int newPort = 0;
        string uriString = string.Empty;
        sessionIdentification = Process.GetCurrentProcess().SessionId;
        portNumber = 14613;
        newPort = portNumber + sessionIdentification;
        uriString = "net.tcp://localhost:" + newPort + "/PulseService";
        Uri uri = new Uri(uriString);
        ServiceHost objServiceHost = new ServiceHost(typeof(Pulse));
        objServiceHost.Description.Endpoints.Clear();
        objServiceHost.AddServiceEndpoint(typeof(Pulse), new NetTcpBinding(), uri);
    }
