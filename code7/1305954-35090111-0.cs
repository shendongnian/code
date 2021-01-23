    class HASPCLass
    {
      static SerialPort m_port;
      
      HASPClass(..)
      {
        lock(m_port)
    	{
    	   if (!Initialized())
    	   {
    	     Initialize();
    	   }
    	}
      }
      void Close () 
      {
        lock(m_port)
    	{
    	   if (Initialized())
    	   {
    	     Uninitialize();
    	   }
    	}
      }
    }
