    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    internal sealed class Program
    {
        private const int BufferSize = 2048;
        private const int Port = 100;
        private readonly List<Socket> clientSockets = new List<Socket>();
        private readonly byte[] buffer = new byte[BufferSize];
        private readonly List<Player> players = new List<Player>();
        private Socket serverSocket;
        private Socket current;
        private int dataSent;
        public static void Main()
        {
            var program = new Program();
            program.SetupServer();
            Console.ReadLine();
            program.CloseAllSockets();
        }
        private void SetupServer()
        {
            Console.WriteLine("Setting up server...");
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, Port));
            serverSocket.Listen(5);
            serverSocket.BeginAccept(AcceptCallback, null);
            Console.WriteLine("Server setup complete");
            Console.WriteLine("Listening on port: " + Port);
        }
        private void CloseAllSockets()
        {
            foreach (Socket socket in clientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            serverSocket.Close();
        }
        private void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;
            try
            {
                socket = serverSocket.EndAccept(AR);
            }
            catch (ObjectDisposedException) // I cannot seem to avoid this (on exit when properly closing sockets)
            {
                return;
            }
            clientSockets.Add(socket);
            socket.BeginReceive(buffer, 0, BufferSize, SocketFlags.None, ReceiveCallback, socket);
            Console.WriteLine("Client connected: " + socket.RemoteEndPoint);
            serverSocket.BeginAccept(AcceptCallback, null);
        }
        private void ReceiveCallback(IAsyncResult AR)
        {
            current = (Socket)AR.AsyncState;
            int received = 0;
            try
            {
                received = current.EndReceive(AR);
            }
            catch (SocketException)
            {
                Console.WriteLine("Client forcefully disconnected");
                current.Close(); // Dont shutdown because the socket may be disposed and its disconnected anyway
                clientSockets.Remove(current);
                return;
            }
            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf);
            if (text.Contains("newuser:"))
            {
                string newuser = text.Replace("newuser:", string.Empty);
                Player newPlayer = new Player(newuser, current.RemoteEndPoint.ToString());
                players.Add(newPlayer);
                SendString("newuser:" + newuser);
                Console.WriteLine(newuser + " has joined the game.");
            }
            else
            {
                // This is where the client text gets mashed together.
                Console.WriteLine(text);
            }
            current.BeginReceive(buffer, 0, BufferSize, SocketFlags.None, ReceiveCallback, current);
        }
        private void SendString(string message)
        {
            try
            {
                byte[] data = Encoding.ASCII.GetBytes(message.ToString());
                current.Send(data);
                // current.BeginReceive(buffer, 0, BufferSize, SocketFlags.None, ReceiveCallback, current);
                dataSent++;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Client disconnected!" + ex.Message);
            }
            Console.WriteLine(dataSent);
        }
    }
    internal sealed class Player
    {
        public Player(string newuser, string toString)
        {
        }
    }
