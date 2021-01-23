    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    
    namespace ConsoleApplication2
    {
        class Program
        {
    
    
            public static void Main()
            {
                try
                {
                    IPAddress ipAd = IPAddress.Parse("127.0.0.1");
                    TcpListener myList = new TcpListener(ipAd, 8001);
    
                    myList.Start();
    
                    Console.WriteLine("The server is running at port 8001...");
                    Console.WriteLine("The local End point is  :" +
                                      myList.LocalEndpoint);
                    Console.WriteLine("Waiting for a connection.....");
    
    
                    while (true)
                    {
    
                        Socket s = myList.AcceptSocket();
                        Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
    
                        byte[] b = new byte[100];
                        int k = s.Receive(b);
                        string szReceived = Encoding.ASCII.GetString(b.Take(k).ToArray());
                        Console.WriteLine(szReceived);
                        Console.WriteLine("Recieved..." + szReceived + "---");
    
                        var split = szReceived.Split('|');
                        if(split.Length==0)return;
    
                        var command = split[0];
                        var parameters = new string[0];
    
                        if (split.Length > 0)
                            parameters = split[1].Split(',');
    
                        switch (command)
                        {
                            case "ping":
                                Console.WriteLine("Ping wird ausgeführt!");
                                ASCIIEncoding asen = new ASCIIEncoding();
    
                                foreach (var p in parameters)
                                    Console.WriteLine(p);
    
                                s.Send(asen.GetBytes("PONG !"));
                                s.Close();
    
                                break;
    
                            case "logout":
    
                                break;
                        }
    
    
                    }
    
    
    
    
                    /* clean up */
    
                    myList.Stop();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error..... " + e.StackTrace);
                }
    
    
    
            }
        }
    }
