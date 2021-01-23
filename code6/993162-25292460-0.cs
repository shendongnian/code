    while (true)
    {
        //Accept a new connection
        Socket mySocket = _listener.AcceptSocket();
        if (mySocket.Connected)
        {
            Byte[] bReceive = new Byte[1024];
            int i = mySocket.Receive(bReceive, bReceive.Length, 0);
            if(i > 0) // added check to make sure data is received
            {
                string sBuffer = Encoding.ASCII.GetString(bReceive, 0, i); // added index and count
                if (sBuffer.Substring(0, 3) != "GET")
                {
                    Console.WriteLine(sBuffer);
                    mySocket.Close();
                    return;
                }    
                ........handle valid requests
            }
        }    
    }
