    public MyResult Calc(MyRequest myReq)
    {
       var mre = new ManualResetEvent(false);
       obj.Callback = result => MyCallback(result, mre);
       obj.CalcAsync();
       mre.WaitOne();
    }
    public void Callback(MyResult result, ManualResetEvent mre)
    {
      try
      {
        ...
      }
      finally
      {
        mre.Set();
      }
    }
