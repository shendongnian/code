     readonly object _lock = new object();
     void Stop()
     {
         lock (_lock)
         {
             _timer.Enabled = false; // equivalent to calling Stop()
         }
     }
     void Timer_Elapsed(...) 
     {
         lock (_lock)
         {
             if (!_timer.Enabled)
                 return;
             // do stuff
         }
     }
