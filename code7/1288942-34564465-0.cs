    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Listen().Wait();
        }
        
        static async Task Listen()
        {
            var listener = new TcpListener(IPAddress.Any, 10000);
            listener.Start();
            Console.WriteLine("Waiting for a connection");
            var socket = await listener.AcceptSocketAsync();
            Console.WriteLine("Client connected!");
        }
    }
