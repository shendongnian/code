    private const string _kuser = "user";
    public void receiveMessage(TcpClient client_Socket)
    {
        messageReceived = streamReader.ReadLine();
        if (messageReceived.EndsWith(_kuser))
        {
            String name = messageReceived.Substring(0, messageReceived.Length - _kuser.Length);
            if (clientList.ContainsKey(name))
            {
                streamWriter.WriteLine("The user already exists");
                streamWriter.Flush();
                return;
            }
            //show who's connected
            Console.WriteLine(name + " is online");
            number_clients++;
            clientList.Add(name, client_Socket);
            string send = string.Join(".", clientList.Keys);
            foreach (var value in clientList.Values.Where(v => v != null))
            {
                // NOTE: I didn't change the problem noted in #2 above, instead just
                // left the code the way you had it, mostly. Of course, in a fully
                // corrected version of the code, your dictionary would contain not
                // just `TcpClient` objects, but some client-specific object specific
                // to your server implementation, in which the `TcpClient` object
                // is found, along with the `StreamReader` and `StreamWriter` objects
                // you've already created for that connection (and any other per-client
                // data that you need to track). Then you would write to that already-
                // existing `StreamWriter` object instead of creating a new one each
                // time here.
                NetworkStream networkStream = value.GetStream();
                StreamWriter networkWriter = new StreamWriter(networkStream);
                networkWriter.WriteLine(send + "connected");
                networkWriter.Flush();
            }
        }
    }
