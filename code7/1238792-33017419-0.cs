    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    namespace testUDP
    {
    class Program
    {
        static volatile Boolean receivingThreadStarted = false;
        public static void DoReceiveFrom()
        {
            byte[] data = new byte[1024];
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 9050);
            EndPoint Remote = (EndPoint)sender;
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            server.Bind(sender);
            receivingThreadStarted = true;
            int recv = server.ReceiveFrom(data, ref Remote);
            Console.WriteLine("Message received from {0}:", Remote.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
        }
        static void Main(string[] args)
        {
             byte[] data = new byte[1024];
            string input;
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            ThreadStart threadDelegate = new ThreadStart(DoReceiveFrom);
            Thread newThread = new Thread(threadDelegate);
            newThread.Start();
            // Waiting to start the receiving thread.
            while (!receivingThreadStarted) Thread.Sleep(100);
            
            string welcome = "Hello, are you there?";
            data = Encoding.ASCII.GetBytes(welcome);
            server.SendTo(data, data.Length, SocketFlags.None, ipep);
            
            while (true)
            {
                input = Console.ReadLine();
                if (input == "exit")
                    break;               
            }
            Console.WriteLine("Stopping client ..");
            server.Close();
        
        }
    }
}
