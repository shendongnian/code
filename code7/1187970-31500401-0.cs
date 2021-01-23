           public static void ReceiveMessages()
            {
                // Receive a message and write it to the console.
                UdpState s = new UdpState();
                Console.WriteLine("listening for messages");
                s.u.BeginReceive(new AsyncCallback(ReceiveCallback), s);
                //block
                while (true) ;
            }
            public static void RecieveMoreMessages(UdpState s)
            {
                s.u.BeginReceive(new AsyncCallback(ReceiveCallback), s);
            }
            public static void ReceiveCallback(IAsyncResult ar)
            {
                UdpClient u = (UdpClient)((UdpState)(ar.AsyncState)).u;
                IPEndPoint e = (IPEndPoint)((UdpState)(ar.AsyncState)).e;
                Byte[] receiveBytes = u.EndReceive(ar, ref e);
                string receiveString = Encoding.ASCII.GetString(receiveBytes);
                Console.WriteLine("Received: {0}", receiveString);
                RecieveMoreMessages(ar.AsyncState);
            }​
