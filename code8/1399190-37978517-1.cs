    using System.Net;
    using System.Net.Sockets;
    public static void getIPv4()
        {
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("10.0.1.20", 1337); // doesnt matter what it connects to
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    Console.WriteLine(endPoint.Address.ToString()); //ipv4
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Failed"); // If no connection is found
            }
        }
