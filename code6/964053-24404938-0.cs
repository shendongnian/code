    System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
    timer1.Interval=10000;//10 seconds
    timer1.Tick += new System.EventHandler(timer1_Tick);
    if (!IsUploadingAvailable())
    {
    	MessageBox.Show("Uploading is not available, please wait until it is ready!", "Upload not available");
    	myButton.Enabled = false;
    	while (IsUploadingAvailable())
    	{
    		 timer1.Start();
    	}
    	MessageBox.Show("Uploading is now available!");
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
    	 //do whatever you want 
    	  timer1.Stop();
    }
