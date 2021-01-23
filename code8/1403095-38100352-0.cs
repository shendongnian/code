    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Web;
    
    namespace Server
    {
        class Program
        {
            static void Main(string[] args)
            {
               
                TcpListener listener = new TcpListener(1302);
                listener.Start();
                while (true)
                {
                    Console.WriteLine("Waiting for connection");
                    TcpClient client = listener.AcceptTcpClient();
                    StreamReader sr = new StreamReader(client.GetStream());
                    StreamWriter sw = new StreamWriter(client.GetStream());
                    try
                    {
                        //client request
                        string request = sr.ReadLine();
                        Console.WriteLine(request);
                        string[] tokens = request.Split(' ');
                        
                        string reply= tokens[1];
                        if (reply == "/")
                        {
                            reply = "Welcome";
                        }
                        //Handle request
    
                        
                        sw.WriteLine("HTTP/1.0 200 OK\n");
                        string data = "You can handle request this way";
                            sw.WriteLine(data);
                            sw.Flush();
    
    
    
                    }catch(Exception ex)
                    {
                        //error\
                        sw.WriteLine("HTTP/1.0 404 OK\n");
                        sw.WriteLine("ERROR");
                    }
                    client.Close();
                }
            }
        }
    }
