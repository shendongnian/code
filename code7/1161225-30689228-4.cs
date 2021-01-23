    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Security;
    using System.Net.Sockets;
    using System.Net.WebSockets;
    using System.Security.Authentication;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace WebSockets
    {
        class Program
        {
            static void Main(string[] args)
            {
                IPEndPoint server = CreateWebSocketServer(1337);
                CreateWebSocketClient(server, 1338);
                CreateWebSocketClient(server, 1339);
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
    
            private static IPEndPoint CreateWebSocketServer(int port)
            {
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, port);
                socket.Bind(endpoint);
                socket.Listen(Int32.MaxValue);
                ListenForClients(socket);
                Console.WriteLine("{0}: Web socket server started at {1}.", DateTime.Now, socket.LocalEndPoint);
                return endpoint;
            }
    
            private static void ListenForClients(Socket socket)
            {
                socket.BeginAccept((result) =>
                {
                    new Thread(() =>
                    {
                        ListenForClients(socket);
                    }).Start();
                    var clientSocket = socket.EndAccept(result);
                    Console.WriteLine("{0}: Connected to the client at {1}.", DateTime.Now, clientSocket.RemoteEndPoint);
                    using (var stream = new SslStream(new NetworkStream(clientSocket), false, (sender, certificate, chain, sslPolicyErrors) =>
                    {
                        if (sslPolicyErrors == SslPolicyErrors.None)
                            return true;
                        return false;
                    }, (sender, targetHost, localCertificates, remoteCertificate, acceptableIssuers) =>
                    {
                        return new X509Certificate2("Certificate.pfx");
                    }, EncryptionPolicy.RequireEncryption))
                    {
                        stream.AuthenticateAsServer(new X509Certificate2("Certificate.pfx"), true, SslProtocols.Tls12, true);
                        stream.Write("Hello".ToByteArray());
                        Console.WriteLine("{0}: Read \"{1}\" from the client at {2}.", DateTime.Now, stream.ReadMessage(), clientSocket.RemoteEndPoint);
                    }
                }, null);
            }
    
            private static void CreateWebSocketClient(IPEndPoint remoteEndpoint, int port)
            {
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                IPEndPoint localEndpoint = new IPEndPoint(IPAddress.Loopback, port);
                socket.Bind(localEndpoint);
                socket.BeginConnect(remoteEndpoint, (result) =>
                {
                    socket.EndConnect(result);
                    Console.WriteLine("{0}: Client at {1} connected to the server at {2}.", DateTime.Now, localEndpoint, remoteEndpoint);
                    using (var stream = new SslStream(new NetworkStream(socket), false, (sender, certificate, chain, sslPolicyErrors) =>
                    {
                        if (sslPolicyErrors == SslPolicyErrors.None)
                            return true;
                        return false;
                    }, (sender, targetHost, localCertificates, remoteCertificate, acceptableIssuers) =>
                    {
                        return new X509Certificate2("Certificate.pfx");
                    }, EncryptionPolicy.RequireEncryption))
                    {
                        stream.AuthenticateAsClient("Test Certificate", new X509Certificate2Collection(new X509Certificate2[] { new X509Certificate2("Certificate.pfx") }), SslProtocols.Tls12, true);
                        stream.Write("Hello".ToByteArray());
                        Console.WriteLine("{0}: Client at {1} read \"{2}\" from the server at {3}.", DateTime.Now, localEndpoint, stream.ReadMessage(), remoteEndpoint);
                    }
                }, null);
            }
        }
    
        public static class StringExtensions
        {
            public static Byte[] ToByteArray(this String value)
            {
                Byte[] bytes = new Byte[value.Length * sizeof(Char)];
                Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
                return bytes;
            }
    
            public static String FromByteArray(this Byte[] bytes)
            {
                Char[] characters = new Char[bytes.Length / sizeof(Char)];
                Buffer.BlockCopy(bytes, 0, characters, 0, bytes.Length);
                return new String(characters).Trim(new Char[] { (Char)0 });
            }
    
            public static int BufferSize = 0x400;
    
            public static String ReadMessage(this SslStream stream)
            {
                var buffer = new Byte[BufferSize];
                stream.Read(buffer, 0, BufferSize);
                return FromByteArray(buffer);
            }
        }
    }
