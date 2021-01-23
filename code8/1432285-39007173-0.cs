    public int DoStuff()
    {
      var res1 = Task.Run(() => LongRunning1());
      var res2 = Task.Run(() => LongRunning2());
      return res1.Result + res2.Result;
    }
