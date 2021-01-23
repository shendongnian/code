    DependencyTelemetry dep = new DependencyTelemetry("DepName", "CommandName", DateTimeOffset.Now.AddSeconds(-1), TimeSpan.FromSeconds(1), true);
    dep.DependencyTypeName = "MyTypeName";
    dep.ResultCode = "200";
    
    new TelemetryClient(new TelemetryConfiguration()
    {
                    InstrumentationKey = "ikey",
                    TelemetryChannel = new InMemoryChannel()
     }).TrackDependency(dep);
