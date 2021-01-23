    private async void button1_Click(object sender, EventArgs e)
    {
    	//Record the time when button was clicked
    	DateTime timeButtonWasClicked = DateTime.Now;
    
    	button1.Enabled = false;
    	label3.ForeColor = System.Drawing.Color.Azure;
    	label3.Text = "Request sent...";
    
    	//Force the label to be repainted
    	label3.Invalidate();
    
    	wbsrv.Url = textBox1.Text;
    	string response = wbsrv.GenerateRandomSensorData(textBox2.Text);
    
    	//If the user has waited less than 3 seconds, 
    	//make them wait the difference, otherwise 
    	//dont force users to wait at least 6 or so seconds
    	TimeSpan ts = DateTime.Now - timeButtonWasClicked;
    	if (ts.Seconds < 3) await Task.Delay(TimeSpan.FromSeconds(3).Subtract(ts));
    
    	label3.Text = response;
    	if (label3.Text.Contains('7')) { 
    		label3.ForeColor = System.Drawing.Color.Green;
    	}
    	else {
    		label3.Text = "Error";
    		label3.ForeColor = System.Drawing.Color.Red;
    	}
    
    	if (lbl_hid) {  //Dont bother testing Booleans for "== true"
    		label3.Show();
    		lbl_hid = false;
    	}
    	button1.Enabled = true;
    }
