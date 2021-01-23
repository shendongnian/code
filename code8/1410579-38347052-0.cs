    void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (stop) 
        {
             // sender is our process instance
             // so we can cast that safely here
             var proc = (Process) sender;
             // brutally kill it
             proc.Kill();
             // or more gently, send a ctrl+C
             // http://stackoverflow.com/a/285041/578411
             proc.StandardInput.Close();
        }
        if (e.Data != null)
        {
            string newLine = e.Data.Trim() + Environment.NewLine;
            MethodInvoker append = () => richTextBox1.Text += newLine;
            richTextBox1.BeginInvoke(append);
         }
    }
