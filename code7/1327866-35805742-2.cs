    using System;
    using System.Threading;
    bool connected = false;
    void init() {
        // Create a new Thread
        new Thread (() =>
        {
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse (serverHost), serverPort);
            client = new Socket (endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try {
                client.SendTimeout = 1000;
                client.ReceiveTimeout = 1000;
                client.Connect (endpoint);
                error = "";
                connected = true;
            } catch(Exception e) {
                connected = false;
                error = e.Message;
                new WaitForSeconds(1);
            }
        }).Start(); // Start the Thread
    }   
