    private async Task ConnectSocket()
        {
            StreamSocket socket = new StreamSocket();
    
            socket.Control.KeepAlive = false;
    
            HostName host = new HostName("localhost");
    
            try
            {
                await socket.ConnectAsync(host, "5463");
    
                Stream streamOut = socket.OutputStream.AsStreamForWrite();
                StreamWriter writer = new StreamWriter(streamOut);
                string request = "Test Self App \n";
                await writer.WriteLineAsync(request);
                await writer.FlushAsync();
                // Code for reading
                Stream streamIn = socket.OutputStream.AsStreamForRead();
                StreamReader reader = new StreamReader(streamIn);
                char[] result = new char[reader.BaseStream.Length];
                await reader.ReadAsync(result, 0, (int)reader.BaseStream.Length);
                // Your data will be in results
                socket.Dispose();
            }
            catch (Exception ex)
            {
                txb_Events.Text += ex.Message;
                //Logs.Add(ex.Message)
            }
    
    
        }
 
