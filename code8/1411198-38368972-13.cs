    static bool AppStillIdle
    {
        get
        {
            Message msg;
            return !PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
        }
    }
    
    public void MainLoop()
    {
        // hook the application's idle event
        Application.Idle += new EventHandler(OnApplicationIdle);
        Application.Run(form);
    }
            
    void OnApplicationIdle(object sender, EventArgs e)
    {
        while (AppStillIdle)
        {
            // Render a frame during idle time (no messages are waiting)
            RenderFrame();
        }
    }
