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
    }
