        public void Connect()
        {
            if (m_tcpClient == null)
            {
                m_tcpClient = new TcpClient();
                m_tcpClient.Connect(m_hostAdress, m_port);
                m_netWorkStream = m_tcpClient.GetStream();
                m_streamReader = new StreamReader(m_netWorkStream);
            }
        }
        public string ReadWithNewLine()
        {
            this.Connect();
            try
            {
                m_readText = m_streamReader.ReadLine().TrimEnd();
            } 
            catch (Exception allExceptions)
            {
                m_readText = "Exception:" + allExceptions.Message;
                if (m_tcpClient!=null)
                {
                    m_tcpClient.Close();
                    m_tcpClient = null; // reset connection
                }
            }
            return m_readText + "\r\n";
        }
