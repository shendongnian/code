    public static void broadcast(byte[] msg, string uName)
        {
            foreach (TcpClient Item in clientsList)
            {
                if (Item != null)
                {
                    try
                    {
                        TcpClient broadcastSocket;
                        broadcastSocket = Item;
                        NetworkStream broadcastStream = broadcastSocket.GetStream();
                        Byte[] broadcastBytes = null;
                        broadcastBytes = msg;
                        Debug.WriteLine("Send Data to everyone from " + uName);
                        broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                        broadcastStream.Flush();
                    }
                    catch (Exception)
                    {
                        //Handle exceptions ....
                    }
                }
            }
        }
