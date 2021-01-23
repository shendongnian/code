    TelemetryConfiguration.Active.InstrumentationKey = "the_key";
    TelemetryConfiguration.Active.TelemetryChannel.DeveloperMode = true;
    var tc = new TelemetryClient();
    tc.TrackRequest("Track Some Request", DateTimeOffset.UtcNow, new TimeSpan(0, 0, 3), "200", true);
    tc.TrackMetric("XYZ Metric", 100);
    tc.TrackEvent("Tracked Event");
    tc.Flush(); //need to do this, otherwise if the app exits the telemetry data won't be sent
