    class HASPCLass
    {
      private static SerialPort m_port;
      private static bool m_initialized;
      private static int m_baudRate;
    
      public HASPClass(int baudRate)
      {
        lock(m_port)
        {
           if (!m_initialized)
           {
             Initialize(baudRate);
           }
        }
      }
      
      private Initialize()
      {
         m_port.open(baudRate);
    	 m_baudRate = baudRate;
    	 m_initialized = true;
      }
      
      private Uninitialize()
      {
         m_port.close();
    	 m_initialized = false;
      }
    
      private ReinitializeIfNeeded(int baudRate)
      {
         if (baudRate != m_baudRate)
    	 {
    	    Uninitialize();
    		Initialize(baudRate);
    	 }
      }
      
      public void Read(int baudRate, out buff) 
      {
        lock(m_port)
    	{
    	  ReinitializeIfNeeded(baudRate);
    	  m_port.Read(out buff);
    	}
      }
      
      public void Write(int baudRate, in buff) 
      {
        lock(m_port)
    	{
          ReinitializeIfNeeded(baudRate);
    	  m_port.Write(buff);
    	}
      }
      
      public void Close() 
      {
        lock(m_port)
        {
           if (m_initialized)
           {
             Uninitialize();
           }
        }
      }
    }
