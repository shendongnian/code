    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    
    public class UDPListener
    {
        private static void StartListener()
        {
            bool done = false;
    
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, 1900);
            
            UdpClient listener = new UdpClient();
            listener.Client.Bind(localEndPoint);
            listener.JoinMulticastGroup(IPAddress.Parse("239.255.255.250"), IPAddress.Parse("10.32.4.129"));
            
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 0);
    
            try
            {
                while (!done)
                {
                    Console.WriteLine("Waiting for broadcast");
                    var bytes = listener.Receive(ref groupEP);
    
                    Console.WriteLine("Received broadcast from {0} :\n {1}\n",
                       groupEP.ToString(),
                       Encoding.ASCII.GetString(bytes, 0, bytes.Length));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                listener.Close();
            }
        }
    
        public static int Main()
        {
            StartListener();
    
            return 0;
        }
    }
