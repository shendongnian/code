    private bool IsRunning = false;
    public void StartServer()
    {
        int port = Convert.ToInt32(txtport.Text);
        string ipaddre = getip();
        IPAddress iP = IPAddress.Parse(ipaddre);
        TcpListener serverSocket = new TcpListener(iP, port);
        TcpClient clientSocket = default(TcpClient);
        int counter = 0;
        serverSocket.Start();
        AppendTxtdata("Server Started , Waiting for Client Connection");
        counter = 0;
        IsRunning = true;
    
        while (IsRunning)
        {
            counter += 1;
            clientSocket = serverSocket.AcceptTcpClient();
            AppendTxtdata(" >> " + "Client No:" + Convert.ToString(counter) + " Connected" + clientSocket.Client.RemoteEndPoint.ToString()+"");
            AppendTxtdata(Environment.NewLine);
            handleClient client = new connectSuccess.handleClient();
            client.startClient(clientSocket, Convert.ToString(counter));
         }
          **AppendTxtdata("Data sent to Client No :" + Convert.ToString(counter));**
         clientSocket.Close();
         serverSocket.Stop();
         AppendTxtdata(" >> " + "exit");
     }
    public void StopServer()
    {
        IsRunning = false;
    }
