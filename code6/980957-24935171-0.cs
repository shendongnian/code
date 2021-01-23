    private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        Process [] localByName = Process.GetProcessesByName("yoursubprocess");
        foreach (var process in processes) 
        {
            process.Kill() ; 
        }
    }
