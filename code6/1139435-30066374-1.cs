    public class SyntheticSourceInitializer : ITelemetryInitializer
    {
        public void Initialize(Microsoft.ApplicationInsights.Channel.ITelemetry telemetry)
        {
            if (MySyntheticCheck(HttpContext.Current.Request))
            {
                telemetry.Context.Operation.SyntheticSource = "MySyntheticSource";
            }
        }
    }
