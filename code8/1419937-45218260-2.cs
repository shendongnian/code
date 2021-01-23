    while(serverIsOn){
        TcpClient cliTemp = server.AcceptTcpClient();
        NetworkStream netTemp = cliTemp.GetStream(); 
        Client cli = new Client(Necessary attributes);
        clientsList.Add(cli);
    }
