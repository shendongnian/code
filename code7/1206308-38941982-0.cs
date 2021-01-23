    protected void Application_Start()
    {    
        DisableApplicationInsightsOnDebug();
        // do the other stuff
    }
    /// <summary>
    /// Disables the application insights locally.
    /// </summary>
    [Conditional("DEBUG")]
    private static void DisableApplicationInsightsOnDebug()
    {
        TelemetryConfiguration.Active.DisableTelemetry = true;
    }
