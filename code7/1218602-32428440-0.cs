            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 2789);
            Console.WriteLine("Client address is:" + groupEP.Address.ToString());
            Console.WriteLine("Client port is:" + groupEP.Port.ToString());
            byte[] data = new byte[1024];
            UdpClient listener = new UdpClient(2789);
            while (true)
            {
                Console.WriteLine("Waiting for client");
                byte[] bytes = listener.Receive(ref groupEP);
                Console.WriteLine("Received Data:" + Encoding.ASCII.GetString(bytes, 0, bytes.Length));
                //sending acknoledgment
                string welcome = "Hello how are you from server?";
                byte[] d1 = Encoding.ASCII.GetBytes(welcome);
                listener.Send(d1, d1.Length, groupEP);
                Console.WriteLine("Message sent to client back as acknowledgment");
            }
