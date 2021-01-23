    static object lockObj;
    public void method()
    {
      if(lockObj == null)
          lockObj = new object;
       lock(lockObj)
       {
         //wait your turn sensitive code here.
       }
    }
    
