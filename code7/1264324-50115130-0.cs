    public class MockTelemetryChannel : ITelemetryChannel
    {
        public IList<ITelemetry> Items
        {
            get;
            private set;
        }
        ...
        public void Send(ITelemetry item)
        {
            Items.Add(item);
        }
    }
    ...
    MockTelemetryChannel = new MockTelemetryChannel();
	TelemetryConfiguration configuration = new TelemetryConfiguration
	{
		TelemetryChannel = MockTelemetryChannel,
		InstrumentationKey = Guid.NewGuid().ToString()
	};
	configuration.TelemetryInitializers.Add(new OperationCorrelationTelemetryInitializer());
	TelemetryClient telemetryClient = new TelemetryClient(configuration);
		
	container.Register<TelemetryClient>(telemetryClient);
