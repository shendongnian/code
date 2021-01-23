     readonly object _lock = new object();
     volatile bool _stopped = false;
     void Stop()
     {
         lock (_lock)
         {
             _stopped = true;
             _timer.Stop();
         }
     }
     void Timer_Elapsed(...) 
     {
         lock (_lock)
         {
             if (_stopped)
                 return;
             // do stuff
         }
     }
