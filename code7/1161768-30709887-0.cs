                private void button1_Click_1(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = @"C:\Users\Administrator\Desktop\Python27\ToolArtworkEmoji.bat";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            proc.OutputDataReceived += proc_OutputDataReceived;
            proc.BeginOutputReadLine();
            proc.WaitForExit();
        {
        private void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            tblog.BeginInvoke(new Action(() => { tblog.Text = e.Data; }));
        }
