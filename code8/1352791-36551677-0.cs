        private static void SetTraceLevel(HttpConfiguration config, TraceLevel level)
        {
            SystemDiagnosticsTraceWriter traceWriter = config.EnableSystemDiagnosticsTracing();
            traceWriter.MinimumLevel = level;
        }
