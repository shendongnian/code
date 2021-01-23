    public void yourThread()
    {      
        if (!m_port.IsOpen)
        {
             m_port.Open(); -- it fails over here when reloaded
        }           
        do
        {
            Break();
            Thread.Sleep(50);
            m_port.Write( new byte[] { 0 }, 0, 1 );
            SendData(RGBdata);
            Thread.Sleep(30);
        }
        while (!stopRequested);
        if (m_port.IsOpen)
        {
             m_port.Close();
             m_port.Dispose();
        }
    }
