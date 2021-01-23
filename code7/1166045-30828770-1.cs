    private static void ThreadProc(object state)
        {
            var client = (TcpClient)state;
            clientsList.Add(client);
            handleClient hclient = new handleClient();
            hclient.startClient(client); //Do whatever with your client here
        }
