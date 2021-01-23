    static public class ServerCommunicator
    {
        static private IPEndPoint serverEndPoint;
        static private TcpClient myClient = new TcpClient();
        static public Connect()
        {
            serverEndPoint = new IPEndPoint(IPAddress.Parse(ServerIP), 8888);
            myClient.Connect(serverEndPoint);
        }
        static public SendMessage(string msg)
        {
            NetworkStream clientStream = myClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(msg);
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }
    }
