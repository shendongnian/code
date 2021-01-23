    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    namespace FolderSync
    {
        class Program
        {
            static void Main()
            {
                var server = new Server();
                server.Start();
                new Client().TransmitFile(
                    new IPEndPoint(IPAddress.Loopback, 35434), 
                    @"f:\downloads\ubuntu-14.04.3-desktop-amd64.iso");
                Console.ReadLine();
                server.Stop();
            }
        }
        class Server
        {
            private readonly TcpListener tcpListener;
            public Server()
            {
                tcpListener = new TcpListener(IPAddress.Loopback, 35434);
            }
            public void Start()
            {
                tcpListener.Start();
                tcpListener.BeginAcceptTcpClient(AcceptTcpClientCallback, null);
            }
            public void Stop()
            {
                tcpListener.Stop();
            }
            private void AcceptTcpClientCallback(IAsyncResult asyncResult)
            {
                //
                // Big fat warning: http://stackoverflow.com/a/1230266/60188
                tcpListener.BeginAcceptTcpClient(AcceptTcpClientCallback, null);
                using(var tcpClient = tcpListener.EndAcceptTcpClient(asyncResult))
                using(var networkStream = tcpClient.GetStream())
                using(var binaryReader = new BinaryReader(networkStream, Encoding.UTF8))
                {
                    var fileName = binaryReader.ReadString();
                    var length = binaryReader.ReadInt64();
                    var mib = length / 1024.0 / 1024.0;
                    Console.WriteLine("Receiving '{0}' ({1:N1} MiB)", fileName, mib);
                        
                    var stopwatch = Stopwatch.StartNew();
                    var fullFilePath = Path.Combine(Path.GetTempPath(), fileName);
                    using(var fileStream = File.Create(fullFilePath))
                        networkStream.CopyTo(fileStream);
                    var elapsed = stopwatch.Elapsed;
                        
                    Console.WriteLine("Received in {0} ({1:N1} MiB/sec)", 
                        elapsed, mib / elapsed.TotalSeconds);
                }
            }
        }
        class Client
        {
            public void TransmitFile(IPEndPoint endPoint, string fileFullPath)
            {
                if(!File.Exists(fileFullPath)) return;
                using(var tcpClient = new TcpClient())
                {
                    tcpClient.Connect(endPoint);
                    using(var networkStream = tcpClient.GetStream())
                    using(var binaryWriter = new BinaryWriter(networkStream, Encoding.UTF8))
                    {
                        var fileName = Path.GetFileName(fileFullPath);
                        Debug.Assert(fileName != null, "fileName != null");
                        //
                        // BinaryWriter.Write(string) does length-prefixing automatically
                        binaryWriter.Write(fileName);
                        using(var fileStream = File.OpenRead(fileFullPath))
                        {
                            binaryWriter.Write(fileStream.Length);
                            fileStream.CopyTo(networkStream);
                        }
                    }
                }
            }
        }
    }
