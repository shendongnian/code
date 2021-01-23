    using System;
    using System.Net.Sockets;
    
    namespace SimpleTCPClient
    {
        class Program
        {
            static void Main(string[] args)
            {
                TcpClient client = new TcpClient("127.0.0.1", 9000);
                try
                {
                    using (NetworkStream stream = client.GetStream())
                    {
                        string message = "Borko";
                        byte[] bytes = Encoding.UTF8.GetBytes(message);
    
                        stream.Write(bytes, 0, bytes.Length);
                    }
                }
                catch (ObjectDisposedException)
                {
                    Console.WriteLine("Lost connection to the server.");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Application isn't connected to the server.");
                }
                finally
                {
                    client.Close();
                }
    
            }
        }
    }
