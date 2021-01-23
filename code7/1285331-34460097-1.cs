        //using System.Timers;
        public App()
        {
            InitializeComponent();
            Timer heartbeatTimer = new System.Timers.Timer();
            heartbeatTimer.Interval = 5000; //5 seconds
            heartbeatTimer.Elapsed += heartbeatTimer_Elapsed;
            ...
            //After established connection, start the timer
            heartbeatTimer.Start();
        }
        void heartbeatTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                //Send Hearbeat
                byte[] msg = System.Text.Encoding.UTF8.GetBytes("HEARTBEAT");
                socket.Send(msg, msg.Length, SocketFlags.None);
            }
            catch (Exception e)
            {
                //Fail to send message - client disconnected.
                Invoke((MethodInvoker)delegate //prevent cross-thread exception
                {
                    ClientIPLabel.Text = "(No Clients Connected)";
                });
            }
        }
