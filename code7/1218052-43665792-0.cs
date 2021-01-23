    public static byte[] ReceiveAll(this Socket socket)
        {
            var buffer = new List<byte>();
            while (socket.Available > 0)
            {
                var currByte = new Byte[1];
                var byteCounter = socket.Receive(currByte, currByte.Length, SocketFlags.None);
                if (byteCounter.Equals(1))
                {
                    buffer.Add(currByte[0]);
                }
            }
            return buffer.ToArray();
        }
