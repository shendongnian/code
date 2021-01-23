     DispatcherTimer _scheduler;
     DispatcherTimer _timer;
     DateTime _start;
     TimeSpan _duration;
     // call this when specified time is changed
     void Schedule(DateTime time)
     {
         _start = time;
         // prevent any logic to run if timer is counting duration
         if(_timer != null)
             return;
         // stop scheduler
         if(_scheduler != null)
             _scheduler.Stop();
         // create new scheduler
         _scheduler = new DispatcherTimer { Interval = _start - DateTime.Now };
         _scheduler.Tick = (s, e) =>
         {
             Start(_duration); // here scheduler will start timer
             _scheduler.Stop(); // after that you don't need scheduler anymore
             _scheduler = null;
         }
         _scheduler.Start();
     }
     // call this when duration is changed
     void Start(TimeSpan duration)
     {
         _duration = duration;
         // prevent from running before starting time
         if(DateTime.Now < _start)
             return;
         // stop running timer
         if(_timer != null)
             _timer.Stop();
         // create timer to count duration including already expired time
         _timer = new DispatcherTimer { Interval = _duration - (DateTime.Now - _start) };
         _timer.Tick = (s, e) =>
         {
             ... // whatever
             _timer.Stop(); // clean up
             _timer = null;
         }
         _timer.Start();
     }
