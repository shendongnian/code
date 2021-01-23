    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; 
    // ... 
    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) 
    { 
        ExceptionTelemetry excTelemetry = new ExceptionTelemetry((Exception)e.ExceptionObject); 
        excTelemetry.SeverityLevel = SeverityLevel.Critical; 
        excTelemetry.HandledAt = ExceptionHandledAt.Unhandled; 
 
        telemetryClient.TrackException(excTelemetry); 
        telemetryClient.Flush(); 
    } 
