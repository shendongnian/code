    public static bool IsADSAlive(String hostName) 
    {
        try {
            using (TcpClient tcpClient = new TcpClient()) 
            {
               tcpClient.Connect(hostName, 3268);
               return true; 
            } 
        }  catch (SocketException) { 
    
          return false ; 
        }
    }
