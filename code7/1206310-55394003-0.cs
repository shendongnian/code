             public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                #region Disable Application Insights debug informations
    #if DEBUG
                TelemetryConfiguration.Active.DisableTelemetry = true;
                TelemetryDebugWriter.IsTracingDisabled = true;
    #endif
                #endregion
    //...
    }
