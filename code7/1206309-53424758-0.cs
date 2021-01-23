    if (_env.IsDevelopment())
    {
    	app.UseDeveloperExceptionPage();
    	TelemetryConfiguration.Active.DisableTelemetry = true;
    	TelemetryDebugWriter.IsTracingDisabled = true;
    }
