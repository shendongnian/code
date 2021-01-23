            var socket = new DatagramSocket();
            //socket.MessageReceived += SocketOnMessageReceived;
            using (var stream = await socket.GetOutputStreamAsync(remoteHost, remotePort))
            {
                using (var writer = new DataWriter(stream))
                {
                   // var data = Encoding.UTF8.GetBytes(message);
                    writer.WriteBytes(packet.Bytes);
                    writer.StoreAsync();
                }
            }
