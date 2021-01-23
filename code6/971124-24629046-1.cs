    using (var t = SetTimer()) 
    {
       while (true)
       {
          lock (Lock)
          {
             if (_allWorkFinsihed)
             {
                t.Enabled = false;
                t.Dispose();
                break;
             }
          }
          Thread.Sleep(2000);
       }
       t.Enabled = false; 
    }
