        public Client()
        {
            ...
            //After connection, CALL ONCE ONLY
            Timer heartbeatTimer = new System.Timers.Timer();
            heartbeatTimer.Interval = 5000; //5 seconds
            heartbeatTimer.Elapsed += heartbeatTimer_Elapsed;
            heartbeatTimer.Start(); 
        }
        void heartbeatTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SendMessage("Heartbeat");
        }
