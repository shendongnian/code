    void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (stop)
        {
            var proc = (Process)sender;
    
            stop = false; // allows you to spawn a new thread after stopping the first
            proc.SynchronizingObject = this; // puts the form in charge of async communication
            proc.Kill(); // terminates the thread
            proc.WaitForExit(); // thread is killed asynchronously, so this goes here...
                    
        }
        if (e.Data != null)
        {
            string newLine = e.Data.Trim() + Environment.NewLine;
            MethodInvoker append = () => richTextBox1.Text += newLine;
            richTextBox1.BeginInvoke(append);
        }
    }
