    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    namespace TestEvents
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Server: Start listening for incoming connections
                const int PORT = 4411;
                var listener = new TcpListener(IPAddress.Any, PORT);
                listener.Start();
                // Client: Connect to listener
                var client = new TcpClient();
                client.Connect(IPAddress.Loopback, PORT);
                // Server: Accept incoming connection from client
                TcpClient server = listener.AcceptTcpClient();
                // Server: Send a message back to client to prove we're connected
                const string msg = "We are now connected";
                NetworkStream serverStream = server.GetStream();
                serverStream.Write(ASCIIEncoding.ASCII.GetBytes(msg), 0, msg.Length);
                // Client: Receive message from server to prove we're connected
                var buffer = new byte[1024];
                NetworkStream clientStream = client.GetStream();
                int n = clientStream.Read(buffer, 0, buffer.Length);
                Console.WriteLine("Received message from server: " + ASCIIEncoding.ASCII.GetString(buffer, 0, n));
                // Client: Close connection and wait a little to make sure we won't ACK any more of server's messages
                Console.WriteLine("Client is closing connection");
                clientStream.Dispose();
                client.Close();
                Thread.Sleep(5000);
                Console.WriteLine("Client has closed his end of the connection");
                // Server: Send a message to client that client could not possibly receive
                serverStream.Write(ASCIIEncoding.ASCII.GetBytes(msg), 0, msg.Length);
                Console.WriteLine(".Write has completed on the server side even though the client will never receive the message.  server.Client.Connected=" + server.Client.Connected);
                // Let the user see the results
                Console.ReadKey();
            }
        }
    }
