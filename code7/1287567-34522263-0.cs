    void ConnectCallback(IAsyncResult ar)
    {
        try
        {            
            theDevSock = (Socket)ar.AsyncState;
            theDevSock.EndConnect(ar);
            //blabla
        }
    }
        
