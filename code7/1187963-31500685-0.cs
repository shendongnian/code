        private void btnReceive_Click(object sender, EventArgs e)
        {
            const int arSize = 100;
            byte[] buffer = new byte[arSize];
            string outPath = @"D:\temp\rxFile.jpg";
            Stream strm = new FileStream(outPath, FileMode.CreateNew);
            try
            {
                listener = new TcpListener(IPAddress.Any, 10);
                listener.Start();
                cl = listener.AcceptTcpClient();
                SocketError errorCode;
                int readBytes = -1;
                int blockCtr = 0;
                int totalReadBytes = 0;
                while (readBytes != 0)
                {
                    readBytes = cl.Client.Receive(buffer, 0, arSize, SocketFlags.None, out errorCode);
                    blockCtr++;
                    totalReadBytes += readBytes;
                    strm.Write(buffer, 0, readBytes);
                }
                strm.Close();
                MessageBox.Show("Received: " + totalReadBytes.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
