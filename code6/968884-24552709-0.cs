    using System;
    using System.Threading;
    
    class TimerExample
    {
        static void Main()
        {
            // Create a timer that signals the delegate to invoke  
            // CheckStatus after one second, and every 1/4 second  
            // thereafter.
            Timer stateTimer = new Timer(tcb);
    
            // Change the period to every 1/2 second.
            stateTimer.Change(0, 500);
        }
        public static void CheckStatus(Object stateInfo) {
            ...
        }
    }
