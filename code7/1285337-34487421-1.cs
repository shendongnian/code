        bool receiveHeartBeat = false;
        public Server()
        {
            ...
            //After connection, CALL ONCE ONLY
            Timer checkHeartbeatTimer = new System.Timers.Timer();
            checkHeartbeatTimer.Interval = 30000; //30 seconds
            checkHeartbeatTimer.Elapsed += checkHeartbeatTimer_Elapsed;
            checkHeartbeatTimer.Start(); 
        }
        void checkHeartbeatTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(receiveHeartBeat)
            {
                Invoke((MethodInvoker)delegate //prevent cross-thread exception
                {
                    ClientIPLabel.Text = "Connected";
                });
            }
            else
            {
                Invoke((MethodInvoker)delegate //prevent cross-thread exception
                {
                    ClientIPLabel.Text = "(No Clients Connected)";
                });
            }
        }
        void WriteMessage(string msg)
        {
            receiveHeartBeat = true;
            // rest of your code
        }
