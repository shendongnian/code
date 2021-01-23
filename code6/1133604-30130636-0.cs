     Threading.Timer tmr= new Threading.Timer(new TimerCallback(Acknowledge),null, 0, Timeout.Infinite);
     private void Acknowldege(object state)
      {
       if(SignalRIsReady)//check if signalr is ready
         {
           _hub.Invoke("Acknowledge","Say Hello to MainHub"); 
           tmr.Change(Timeout.Infinite, Timeout.Infinite);//wait until next event occurs
         }
      }
     _hub.On<String>("Ping",(string s) =>
            {
                Console.WriteLine(s + " from MainHub "); 
                tmr.Change(50, Timeout.Infinite);// call callback after 50ms
               
            });
