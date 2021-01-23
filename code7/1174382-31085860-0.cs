    private bool IsConnected(Socket socketForClient)
    {
             get {return !(Socket.Poll(1, SelectMode.SelectRead) 
                                      && socketForClient.Available ==0)}
    }
..
    while(IsConnected())
    {
      // Do Stuff
    }
