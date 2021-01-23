      byte[] reap = new byte[2048];
      var memStream = new MemoryStream();
          IPEndPoint ipe = new IPEndPoint(IPAddress.Any,
                                            3000); //listen on all local addresses and 8888 port
            TcpListener tcpl = new TcpListener(ipe);
        
     tcpl.Start(); // block application until data and connection
     TcpClient tcpc = tcpl.AcceptTcpClient();
   
      int bytesread = tcpc.GetStream().Read(resp, 0, resp.Length);
      while (bytesread > 0)
      {
          memStream.Write(resp, 0, bytesread);
          bytesread = tcpc.GetStream().Read(resp, 0, resp.Length);
      }
