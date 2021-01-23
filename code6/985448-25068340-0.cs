    Object lockThis = new Object();    
    void read()
    {
      lock (lockThis)
      {    
         //Critical Section
      }
    }
    void write()
    {
      lock (lockThis)
      {    
         //Critical Section
      }
    }
