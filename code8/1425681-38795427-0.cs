    public partial class ProgressBarSample
    {
	    TimeSpan pbShowDuration = [blah blah];
	    DateTime pbShowFrom = DateTime.MinDate;
	
        public ProgressBarSample
	    {
	    	progressBar1.Style = ProgressBarStyle.Marquee;
	    	progressBar1.Visible = false;
	    }
        private void btnDelete_Click(object sender, EventArgs e)
	    {
	    	progressBar1.Visible = true;
	    	pbShowFrom = DateTime.Now;
	    	timer1.Enabled = true;
	    	// run stored procedure that takes around 5 minutes
	    }
	
	    private void timer1_Tick(object sender, EventArgs e)
	    {
	    	if ((DateTime.Now - pbShowFrom) > pbShowDuration)
	    	{
	    		timer1.Enabled = false;
	    		progressBar1.Visible = false;			
	    	}
	    }
    }
