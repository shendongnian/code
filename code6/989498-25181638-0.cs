    demoAlertToolStripMenuItem.CheckOnClick = true; // this makes the button a "toggle" one
    
    void demoAlertToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
    {
        if (demoAlertToolStripMenuItem.Checked)
        {
            // do one action, e.g. start the timer
            …
        }
        else
        {
            // undo the action, e.g. stop the timer
            …
        }
    }
