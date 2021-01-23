    public string vmax(string prevValue)
    {
    
        System.Diagnostics.Process[] ieProcs = Process.GetProcessesByName(label92.Text);
        if(ieProcs.Length == 0)
             return prevValue;
        ...
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        label90.Text = vmax(label90.Text);
    }
