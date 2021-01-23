    private void demoAlertToolStripMenuItem_Click(object sender, EventArgs e)
    {
    	if (timer1.Enabled) // timer is running
    	{
    		demoAlertToolStripMenuItem.ForeColor = Color.Red;
    		timer1.Stop();
    	}
    	else  // timer is stopped
    	{
    		demoAlertToolStripMenuItem.ForeColor = Color.Black;
    		timer1.Start();
    	}     
    }
