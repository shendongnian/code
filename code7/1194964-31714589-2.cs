    using System;
    using System.Timers;
    
    pubic class MyElapsedEvent : EvetArgs
    {
        pubic MyEllapsedEventArgs(fireTime = DateTime.Now)
        {
            FireTime = fireTime;
        }
    
        public FirTime { get; private set }
    }
