    var _ReliableChannel = new ReliableTelemetryChannel ();
    var _ReliableConfiguration = new TelemetryConfiguration ();
    _ReliableConfiguration.TelemetryChannel = _ReliableChannel;
    var _ReliableClient = new TelemetryClient (_ReliableConfiguration);
    _ReliableClient.InstrumentationKey = "...";
