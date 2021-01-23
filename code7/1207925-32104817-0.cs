    public sealed class UdpUtility
    {
        // Our UDP Port
        private const int broadcastPort = 11000;
        // Our message to ask if anyone is ready for connection
        private const string askMessage = "ARE ANYONE OUT THERE?";
        // Our answer message
        private const string responseMessage = "I AM HERE!";
        // We use this method to look for a client to connect with us.
        // It will send a broadcast to the network, asking if any client is ready for connection.
        public void SendBroadcastMessage()
        {
            var udp = new UdpClient(broadcastPort);
            var endpoint = new IPEndPoint(IPAddress.Broadcast, broadcastPort);
            try
            {
                var bytes = Encoding.ASCII.GetBytes(askMessage);
                udp.Send(bytes, bytes.Length, endpoint);
            }
            catch (Exception ex)
            {
                // Treat your connection exceptions here!
            }
        }
        // This method will start a listener on the port.
        // The client will listen for the ask message and the ready message.
        // It can then, answer back with a ready response, or start the TCP connection.
        public void ListenBroadcastMessage()
        {
            var udp = new UdpClient(broadcastPort);
            var endpoint = new IPEndPoint(IPAddress.Broadcast, broadcastPort);
            bool received = false;
            try
            {
                while (!received)
                {
                    // We start listening broadcast messages on the broadcast IP Address interface.
                    // When a message comes, the endpoing IP Address will be updated with the sender IP Address.
                    // Then we can answer back the response telling that we are here, ready for connection.
                    var bytes = udp.Receive(ref endpoint);
                    var message = Encoding.ASCII.GetString(bytes);
                    if (message == askMessage)
                    {
                        // Our client received the ask message. We must answer back!
                        // When the client receives our response, his endpoint will be updated with our IP Address.
                        // The other client can, then, start the TCP connection and do the desired stuff.
                        var responseBytes = Encoding.ASCII.GetBytes(responseMessage);
                        udp.Send(responseBytes, responseBytes.Length, endpoint);
                    }
                    else if (message == responseMessage)
                    {
                        // We received a connection ready message! We can stop listening.
                        received = true;
                        // We received a response message! 
                        // We can start our TCP connection here and do the desired stuff.
                        // Remember: The other client IP Address (the thing you want) will be on the
                        // endpoint object at this point. Just use it and start your TCP connection!
                    }
                }
            }
            catch (Exception ex)
            {
                // Treat your connection exceptions here!
            }
        }
    }
