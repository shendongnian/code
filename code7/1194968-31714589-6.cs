    using System;
    using System.Timers;
    
    public class MyElapsedEventArgs : EventArgs
    {
        public MyElapsedEventArgs(DateTime fireTime)
        {
            FireTime = fireTime;
        }
    
        public DateTime FireTime { get; private set; }
    }
