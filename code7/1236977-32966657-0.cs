    bool isConnect = false;
   
    void ConnectAndRead(){  //Instead of Start(), I use this to control the connection
      using (TcpClient client = new TcpClient() ){
        client.Connect(your_ip, your_port);
        if (!client.Connected) throw new Exception();
        isConnect = true;
        NetworkStream stream = client.GetStream();
        StreamReader sr = new StreamReader (stream );
        StreamWriter sw = new StreamWriter (stream );
        sw.AutoFlush = true;
        while (true) {
            //I copy your source and paste here!!
            string linha = sr.ReadLine();
            if (linha == null) break;
            Debug.Log (linha);
        }
      }
    }
