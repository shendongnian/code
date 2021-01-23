    object @lock = new object(); //is work being done?
    void ProcessRequest(Context ctx) {
     if (!Monitor.Enter(@lock))
      SendBusy();
     else {
      ProcessInner(ctx); //actually do some work
      Monitor.Exit(@lock);
     }
    }
