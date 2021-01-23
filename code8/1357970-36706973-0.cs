    private System.Timers.Timer timer1;
    
    protected override void OnStart(string[] args)
    {
        this.timer1 = new System.Timers.Timer(30000) { AutoReset = true };
        this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
        this.timer1.Start(); 
    }
    
    private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        try 
        {
            // Do Work
        }
        catch (Exception ex) 
        {
            // Logging
        }
        finally 
        {
            timer1.Start()
        }
    }
