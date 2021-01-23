    [TestMethod]
    public void Test1()
    {
      Exception thread_ex = null;
      Application.ThreadException += (o, e) =>
      {
        thread_ex = e.Exception;  //store the exception from the UI thread
        Application.ExitThread(); //kill the UI thread
      };
      DoTest();                   //do the test
      if (thread_ex != null)      //if an exception was stored
        throw thread_ex;          //throw it again on the main thread
    }
