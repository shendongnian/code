    private static object syncRoot = new object();
    private static bool initialized = false;
    public void Application_BeginRequest(object sender, EventArgs e)
    {
        if (!initialized)
        {
            lock (syncRoot)
            {
                if (!initialized)
                {
                    // Do your stuff here with HttpContext
    
                    initialized = true;
                }
            }
        }
    }
