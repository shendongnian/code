        //using System.Timers;
        private void ListenForClients()
        {
            this.tcpListener.Start();
            Timer heartbeatTimer = new System.Timers.Timer();
            heartbeatTimer.Interval = 5000; //5 seconds
            heartbeatTimer.Elapsed += heartbeatTimer_Elapsed;
            heartbeatTimer.Start();
            //rest of your code
        }
        void heartbeatTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                SendMessage("Can be anything :D");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); //Check what is the exception
                
                //Fail to send message - client disconnected.
                Invoke((MethodInvoker)delegate //prevent cross-thread exception
                {
                    ClientIPLabel.Text = "(No Clients Connected)";
                });
            }
        }
