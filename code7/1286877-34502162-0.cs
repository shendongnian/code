    //Stop:
    isStopping = true;
    this.tcpListener.Stop();
    //...
    private void ListenForClients()
    {
        this.tcpListener.Start();            
        while (true)
        {
            try
            {
                TcpClient client = this.tcpListener.AcceptTcpClient();
                //...
            }
            catch (Exception e)
            {
                if (!isStopping) throw; //don't swallow too much!
            }                              
        }
    }
