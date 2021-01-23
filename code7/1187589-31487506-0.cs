    private void button1_Click(object sender, EventArgs e)
    {
    	AutoResetEvent waiter = new AutoResetEvent(false);
    	IPAddress ip = IPAddress.Parse("193.168.1.2");
    	var pingSender = new Ping();
    
    	pingSender.PingCompleted += PingCompletedCallback;
    	pingSender.SendAsync(ip, 1000, waiter);
    }
    
    private void PingCompletedCallback(object sender, PingCompletedEventArgs e)
    {
    	// If an error occurred, display the exception to the user. 
    	if (e.Error != null)
    	{
    		MessageBox.Show(string.Format("Ping failed: {}", e.Error.ToString()), 
    						"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    
    		// Let the main thread resume. 
    		((AutoResetEvent)e.UserState).Set();
    	}
    
    	PingReply reply = e.Reply;
    
    	DisplayReply(reply);
    
    	// Let the main thread resume.
    	((AutoResetEvent)e.UserState).Set();
    }
    
    public void DisplayReply(PingReply reply)
    {
    	if (reply == null)
    		return;
    
    	ping_box.Text = string.Format("Ping status: {0}, RoundTrip time: {1}", 
    									reply.Status,
    									reply.RoundtripTime.ToString());
    	
    }
