    var operationId = default(string);
    try
    {
        var telemetry = new RequestTelemetry();
        TelemetryConfiguration
            .Active
            .TelemetryInitializers
            .OfType<OperationIdTelemetryInitializer>()
            .Single()
            .Initialize(telemetry);
        operationId = telemetry.Context.Operation.Id;
    }
    catch { }
