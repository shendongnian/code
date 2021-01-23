    void OnApplicationIdle(object sender, EventArgs e)
    {
        while (AppStillIdle)
        {
            // Render a frame during idle time (no messages are waiting)
            RenderFrame();
            Thread.Sleep(0); // <------------- be graceful
        }
    }
