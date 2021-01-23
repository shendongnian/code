    private void Ping_click(object sender, EventArgs e)
            {
                AutoResetEvent waiter = new AutoResetEvent(false);
    
                Ping pingSender = new Ping(); //creates a new 'pingSender' Ping object
    
                pingSender.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);
    
                // Create a buffer of 32 bytes of data to be transmitted.
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
    
                int timeout = 1000;
    
                pingSender.SendAsync(address, timeout, buffer, waiter);
    
                //Change the label here
                label1.Text = "the ping was: " + reply.Status.ToString();
                Show();
                Refresh();
            }
