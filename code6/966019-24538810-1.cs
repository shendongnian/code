        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                pipeServ.WaitForConnection(); //opcjonalne?
                StreamWriter sw = new StreamWriter(pipeServ);
                sw.AutoFlush = true;
                tcpCamera = new TcpClient();
                tcpCamera.Connect(ipAddress, camPort);
                NetworkStream camStream = tcpCamera.GetStream();
                
                int read = 0;
                byte[] bytes = new byte[tcpCamera.ReceiveBufferSize];
                while (tcpCamera.Connected)
                {
                    read = camStream.Read(bytes, 0, tcpCamera.ReceiveBufferSize);
                    if (read > 0)
                        pipeServ.Write(bytes, 0, read);
                }
            }
            catch (IOException ex)
            {
                //Broken pipe - result of Mplayer exit
                //MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
