    // Assume that these are somewhere globals of your forms
    RichTextBox rtb = new RichTextBox();
    CheckBox chkPause = new CheckBox();
    StringBuilder sb = new StringBuilder();
    
    protected void chkPause_CheckedChanged(object sender, EventArgs e)
    {
        if(!chkPause.Checked)
        {
            rtb.AppendText = sb.ToString();
            // Do not forget to clear the buffer to avoid errors 
            // if the user repeats the stop/go cycle.
            sb.Clear();
        }
        else
        {
            // Start a timer to resume normal flow after a timer elapses.
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = GetSuspensionMilliseconds();
            t.Tick += onTick;
            t.Start();
        }
    }
    protected void onTick(object sender, EventArgs e)
    {
        if (chkPause.Checked)
        {
            // Set to false when the timing elapses thus triggering the CheckedChanged event 
            chkPause.Checked = false;
            System.Windows.Forms.Timer t = sender as System.Windows.Forms.Timer;
            t.Stop();
        }
    }
