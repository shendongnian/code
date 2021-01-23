    private void SetupLoader()
    	{
    		string query = "GET " + "/" + folderPath + URIToLoad.Replace(" ", "%20") + " HTTP/1.1\r\n" +
            "Host: "http://myserver.com"\r\n" +
            "User-Agent: undefined\r\n" +
            "Connection: close\r\n" +
            "\r\n";
            if (!Directory.Exists(Application.persistentDataPath + "/" + folderPath))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/" + folderPath);
            }
    
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            client.Connect(http://myserver.com", 80);
    
            networkStream = new NetworkStream(client);
    
            var bytes = Encoding.Default.GetBytes(query);
            networkStream.Write(bytes, 0, bytes.Length);
    
            var bReader = new BinaryReader(networkStream, Encoding.Default);
    
            string response = "";
            string line;
            char c;
    
            do
            {
                line = "";
                c = '\u0000';
                while (true)
                {
                    c = bReader.ReadChar();
                    if (c == '\r')
                        break;
                    line += c;
                }
                c = bReader.ReadChar();
                response += line + "\r\n";
            }
            while (line.Length > 0);
    
            Regex reContentLength = new Regex(@"(?<=Content-Length:\s)\d+", RegexOptions.IgnoreCase);
            // Get the total number of bytes of the file we are downloading
            contentLength = uint.Parse(reContentLength.Match(response).Value);
            fileStream = new FileStream(Application.persistentDataPath + "/" + folderPath + URIToLoad, FileMode.Create);
    		
       		totalDownloaded = 0;
            contentDownloading = true;
    	}   
