    Timer _timer;
    using (_timer = SetTimer()) 
    {
       while (true)
       {
          lock (Lock)
          {
             if (_allWorkFinsihed)
             {
                _timer.Enabled = false;
                _timer.Dispose();
                break;
             }
          }
          Thread.Sleep(2000);
       }
       t.Enabled = false; 
    }
