    private static void SocketTime(int readTimeout, Random random)
            {
                var ip = IPAddress.Parse("127.0.0.1");
                const int hostPort = 80;
    
                var hostep = new IPEndPoint(ip, hostPort);
                var sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    
                sock.Connect(hostep);
                var uniqueID = random.Next().ToString();
                var get = $"GET http://localhost/api/apitest/testcancel/{uniqueID} HTTP/1.1\r\n" +
                          "x-apikey: somekey\r\n" +
                          "Host: foo.com\r\n" +
                          "Connection: Close\r\n" +
                          "\r\n";
    
    
                var getBytes = Encoding.UTF8.GetBytes(get);
                sock.ReceiveTimeout = readTimeout;
                sock.Send(getBytes);
    
                var responseData = new byte[1024];
                try
                {
                    var bytesRead = sock.Receive(responseData);
                    var responseString = new StringBuilder();
                    while (bytesRead != 0)
                    {
                        responseString.Append(Encoding.ASCII.GetChars(responseData), 0, bytesRead);
                        bytesRead = sock.Receive(responseData);
                    }
                    Console.WriteLine($"SUCCESS => Unique ID = {uniqueID}, Timeout = {readTimeout}");
                }
                catch (SocketException e)
                {
                    if (e.SocketErrorCode == SocketError.TimedOut)
                    {
                        Console.WriteLine($"FAIL => Unique ID = {uniqueID}, Timeout = {readTimeout}");
                    }
                    else
                    {
                        Console.WriteLine("UNHNALDED ERROR: " + e.Message);
                    }
                    
                }
                finally
                {
                    sock.Dispose();
                }
            }
