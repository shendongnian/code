    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    namespace SimpleListener
    {
        class Program
        {
            const int PORT = 8070;
            const int BACKLOG = 5;
            static Socket socket;
            private static byte[] rcvBuffer;
            private static int bytesRcvd;
            private static string message;
        
            static void Main(string[] args)
            {
                try
                {
                    StartListener();
                    Listen();
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message);
                }
            }
            private static void StartListener()
            {
                try
                {
                    //Initialize socket and start listenning
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Bind(new IPEndPoint(IPAddress.Any, PORT));
                    socket.Listen(BACKLOG);
                    ShowMessage("I'm listenning now..");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            private static void Listen()
            {
                try
                {
                    rcvBuffer = new Byte[256];
                    bytesRcvd = 0;
                    message = string.Empty;
 
                    //Start listnening/waiting for client to connect
                    while (true)
                    {
                        var client = socket.Accept();
                        ShowMessage("Client with IP " + client.RemoteEndPoint.ToString() + " connected!");
                        //Client has connected, keep receiving/displaying data
                        while (true)
                        {
                            try
                            {
                                bytesRcvd = 0;
                                message = string.Empty;
                                bytesRcvd = client.Receive(rcvBuffer, 0, rcvBuffer.Length, SocketFlags.None);
                                message = Encoding.ASCII.GetString(rcvBuffer, 0, bytesRcvd);
                                Console.WriteLine(DateTime.Now.ToLongTimeString() + " - " + message);
                            }
                            catch (SocketException)
                            {
                                //Lets ignore client disconected here, but display some sort of message to user
                                ShowMessage("Client with IP " + client.RemoteEndPoint.ToString() + " has disconnected ...");
                                break;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            private static void ShowMessage(string message)
            {
                Console.WriteLine(message);
                Console.WriteLine();
            }
        }
    }
