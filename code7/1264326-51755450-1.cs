        private TelemetryClient InitializeMockTelemetryChannel()
        {
            // Application Insights TelemetryClient doesn't have an interface (and is sealed)
            // Spin -up our own homebrew mock object
            MockTelemetryChannel mockTelemetryChannel = new MockTelemetryChannel();
            TelemetryConfiguration mockTelemetryConfig = new TelemetryConfiguration
            {
                TelemetryChannel = mockTelemetryChannel,
                InstrumentationKey = Guid.NewGuid().ToString(),
            };
            TelemetryClient mockTelemetryClient = new TelemetryClient(mockTelemetryConfig);
            return mockTelemetryClient;
        }
