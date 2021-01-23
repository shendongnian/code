    private static int WM_QUERYENDSESSION = 0x11;
    private static bool systemShutdown = false;
    protected override void WndProc(ref System.Windows.Forms.Message m)
    {
        if (m.Msg==WM_QUERYENDSESSION)
        {
            MessageBox.Show("queryendsession: this is a logoff, shutdown, or reboot");
            systemShutdown = true;
        }
        // If this is WM_QUERYENDSESSION, the closing event should be
        // raised in the base WndProc.
        base.WndProc(ref m);
    
    } //WndProc 
  
    private void Form1_Closing(
        System.Object sender, 
        System.ComponentModel.CancelEventArgs e)
    {
        if (systemShutdown)
            // Reset the variable because the user might cancel the 
            // shutdown.
        {
            systemShutdown = false;
            if (DialogResult.Yes==MessageBox.Show("My application", 
                "Do you want to save your work before logging off?", 
                MessageBoxButtons.YesNo))
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
