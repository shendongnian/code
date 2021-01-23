    TelemetryConfiguration config = TelemetryConfiguration.CreateDefault();
    
    var loggingContext = //new logging context with operation name and correlation id
    config.TelemetryInitializers.Add(new MiTelemetryInitialiser(loggingContext));
    
    while(!cancellationToken.IsCancellationRequested) {
        // 1. Get message from the queue
        // 2. Extract operation name and Correlation Id from the message
        TelemetryClient telemetryClient = new TelemetryClient(config);        
    
        // do work
    
        client.Flush();
    }
