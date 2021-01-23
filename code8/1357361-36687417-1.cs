    public string vmax(string prevValue)
    {
        try
        {
            System.Diagnostics.Process[] ieProcs = Process.GetProcessesByName(label92.Text);
            if(ieProcs.Length == 0)
                 return prevValue;
            ...
         }
         catch
         {
             return prevValue;
         }
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        label90.Text = vmax(label90.Text);
    }
