    //Declare a timer control
    private static System.Timers.Timer aTimer;
    //We need to check when the response is populated between two methods, so I've declared it as a private member variable
    private string response = string.Empty;
    private void button1_Click(object sender, EventArgs e)
    {
    	button1.Enabled = false;
    	label3.ForeColor = System.Drawing.Color.Azure;
    	label3.Text = "Request sent...";
    	//Force the label to be repainted
    	label3.Invalidate();
        //Instantiate the timer and set a one second interval.
        aTimer = new System.Timers.Timer();
        aTimer.Interval = 1000;
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += OnTimedEvent;
        // Start the timer
        aTimer.Enabled = true;
    	wbsrv.Url = textBox1.Text;
    	response = wbsrv.GenerateRandomSensorData(textBox2.Text);
    }
    private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
    {
        //Check the response string variable is NOT empty
        if  (!string.IsNullOrEmpty(response)) 
        {
           label3.Text = response;
        }
        else
        {
           return;
        }
    	if (label3.Text.Contains('7')) { 
    		label3.ForeColor = System.Drawing.Color.Green;
    	}
    	else {
    		label3.Text = "Error";
    		label3.ForeColor = System.Drawing.Color.Red;
    	}
    
    	if (lbl_hid) { 
    		label3.Show();
    		lbl_hid = false;
    	}
    	button1.Enabled = true;
    }
