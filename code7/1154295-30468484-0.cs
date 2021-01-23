    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    internal sealed class Program
    {
        private const int Port = 100;
        private readonly Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private bool hasLoggedin;
        private int dataSent;
        public static void Main()
        {
            var client = new Program();
            client.ConnectToServer();
            client.Exit();
        }
        private void ConnectToServer()
        {
            int attempts = 0;
            while (!clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    string ip = "127.0.0.1";
                    Console.WriteLine("Port[default]: " + Port);
                    Console.WriteLine("Connection attempt to " + ip + ": " + attempts + " attempts");
                    var address = IPAddress.Parse(ip);
                    clientSocket.Connect(address, Port);
                }
                catch (SocketException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            Console.WriteLine("Connected!");
            SendLoginPacket();
        }
        private void SendLoginPacket()
        {
            if (hasLoggedin == false)
            {
                SendString("newuser:" + Guid.NewGuid());
                hasLoggedin = true;
            }
            RequestLoop();
        }
        private void RequestLoop()
        {
            while (true)
            {
                SendData();
                ReceiveResponse();
            }
        }
        private void Exit()
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
        private void SendData()
        {
            const string Data = "username:100|200";
            SendString(Data);
        }
        private void SendString(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            Console.WriteLine("Sent: " + text);
            clientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
            dataSent++;
            Console.WriteLine(dataSent);
        }
        private void ReceiveResponse()
        {
            var buffer = new byte[2048];
            int received = clientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0)
            {
                return;
            }
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = Encoding.ASCII.GetString(data);
            if (text.Contains("newuser:"))
            {
                string str = text.Replace("newuser:", string.Empty);
                Console.WriteLine(str + " has joined the game.");
            }
            Console.WriteLine("Clients connected.");
        }
    }
