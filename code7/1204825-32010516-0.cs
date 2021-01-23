    const int MINUTE = 1000 * 60;
    static void Main(string[] args)
    {
      System.Threading.Thread.Sleep(15 * MINUTE);          
      while(!HasFileBeenUploaded())
      {               
       System.Threading.Thread.Sleep(MINUTE);
      }
    }  
