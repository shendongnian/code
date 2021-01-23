    private void CopyToClipboard(TextBox textBox)
    {
        if (textBox.Text != "")
        {
            textBox.BackColor = System.Drawing.Color.MistyRose;
            Clipboard.SetText(textBox.Text);
            // Create a timer with a 1 second interval.
            System.Timers.Timer aTimer = new System.Timers.Timer(1000);
        
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
    
            // Only tick one time
            aTimer.AutoReset = false;
            // Start timer
            aTimer.Enabled = true;
        }
    }
    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        this.BeginInvoke((MethodInvoker)delegate
        {
            textBox.BackColor = System.Drawing.SystemColors.Window;
        });
    }
