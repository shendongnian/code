    static void Main(string[] args)
    {
        TcpListener server = null;
        try
        {
            // Set the TcpListener on port 13000.
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            // TcpListener server = new TcpListener(port);
            server = new TcpListener(localAddr, port);
            // Start listening for client requests.
            server.Start();
            // Buffer for reading data
            Byte[] bytes = new Byte[256];
            String data = null;
            WebRequest request;
            WebResponse response;
            // Enter the listening loop. 
            while (true)
            {
                Console.Write("Waiting for a connection... ");
                // Perform a blocking call to accept requests. 
                // You could also user server.AcceptSocket() here.
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");
                data = null;
                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();
                int i;
                String[] input;
                // Loop to receive all the data sent by the client. 
                while (stream.DataAvailable)
                {
                    data = null;
                    i = stream.Read(bytes, 0, bytes.Length);
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine(String.Format("Received: {0}", data));
                    input = data.Split();
                    Console.WriteLine("\n\r\n input[1]" + input[1] + "\n");
                    Stream dataStream;
                    StreamReader reader;
                    string responseFromServer;
                    try
                    {
                        request = WebRequest.Create(input[1]);
                        response = request.GetResponse();
                        // Process the data sent by the client.
                        data = data.ToUpper();
                        dataStream = response.GetResponseStream();
                        
                        MemoryStream ms = new MemoryStream();
                        dataStream.CopyTo(ms);
                        
                        ms.Position = 0;
                        // Open the stream using a StreamReader for easy access.
                        reader = new StreamReader(ms);
                        // Read the content.
                        responseFromServer = reader.ReadToEnd();
                        // Display the content
                        Console.WriteLine(responseFromServer);
                        // Clean up the streams and the response.
                        byte[] msg = ms.ToArray();
                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        // Console.WriteLine("Sent: {0}", data);
                        //stream.Write();
                        reader.Close();
                        response.Close();
                    }
                    catch (System.UriFormatException e)
                    {
                        Console.WriteLine("Exception due to" + e.Data);
                        Console.WriteLine("Input[1] = " + input[1]);
                    }
                    data = null;
                }
                // Shutdown and end connection
                client.Close();
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
        finally
        {
            // Stop listening for new clients.
            server.Stop();
        }
        Console.WriteLine("\nHit enter to continue...");
        Console.Read();
    }
