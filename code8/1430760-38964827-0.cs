    public class CustomeWebRequestTelemetryModule :  Microsoft.ApplicationInsights.Extensibility.ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            if (telemetry != null && System.Diagnostics.Debugger.IsAttached)
            {
                telemetry.Context.InstrumentationKey = "00000000-0000-0000-0000-000000000000";
            }
        }
    }
