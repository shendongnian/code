    using System;
    using System.Timers;
    
    pubic class MyElapsedEventArgs : EventArgs
    {
        pubic MyElapsedEventArgs(DateTime fireTime = DateTime.Now)
        {
            FireTime = fireTime;
        }
    
        public DateTime FireTime { get; private set }
    }
