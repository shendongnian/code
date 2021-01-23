    static void ServerTask(object clnObj)
    {
        TcpClient client = clnObj as TcpClient;
    
        BinaryWriter bw = new BinaryWriter(client.GetStream());
    
        int k =99;
        bw.Write(k);
    
        client.Close();
    }
