    private bool IsConnected(Socket socketForClient)
    {
             get {return !(Socket.Poll(1, SelectMode.SelectRead) 
                                      && socketForClient.Available ==0)}
    }
..
    while(IsConnected())
    {
        string theString = streamReader.ReadLine();
        Console.WriteLine("Message recieved by client:" + theString);
        // Do Stuff
    }
