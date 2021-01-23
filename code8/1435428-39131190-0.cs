    namespace ApmTips.Tools
    {
        using Microsoft.ApplicationInsights.Extensibility;
        using Microsoft.Diagnostics.Tracing;
        using System.Diagnostics;
        public class ExtendedIDTelemetryInitializer : ITelemetryInitializer
        {
            public void Initialize(Microsoft.ApplicationInsights.Channel.ITelemetry telemetry)
            {
                telemetry.Context.[some field] = [some value];
            }
        }
    }
