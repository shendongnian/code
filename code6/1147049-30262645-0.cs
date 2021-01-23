    byte[] buffer = new byte[2048];
            int bytes;
            using (TcpClient tc = new TcpClient("192.168.1.2", 808))
            {                
                button1.Enabled = false;                
                NetworkStream stream = tc.GetStream();
                // Establish Tcp tunnel
                byte[] tunnelRequest = Encoding.UTF8.GetBytes(String.Format("CONNECT {0}:80  HTTP/1.1\r\nHost: {0}\r\n\r\n", "bot.whatismyipaddress.com"));
                stream.Write(tunnelRequest, 0, tunnelRequest.Length);
                stream.Flush();
                // Read response to CONNECT request
                bytes = stream.Read(buffer, 0, buffer.Length);
                richTextBox1.Text  = Encoding.UTF8.GetString(buffer, 0, bytes);
                // Establish Get
                tunnelRequest = Encoding.UTF8.GetBytes(String.Format(@"GET / HTTP/1.1
    Host: bot.whatismyipaddress.com
    Connection: close
    Cache-Control: max-age=0
    Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8
    User-Agent: Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.76 Safari/537.36 OPR/28.0.1750.40
    DNT: 1
    Accept-Encoding: gzip, deflate, lzma, sdch
    Accept-Language: en-US,en;q=0.8
    "));
                stream.Write(tunnelRequest, 0, tunnelRequest.Length);
                stream.Flush();
                bytes = stream.Read(buffer, 0, buffer.Length);
                richTextBox1.Text += Encoding.UTF8.GetString(buffer, 0, bytes);
                button1.Enabled = true;
