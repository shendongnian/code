    // setup the client
    TelemetryClient tc = new TelemetryClient();
    tc.InstrumentationKey = "key copied from portal";
    // Set session data:
    tc.Context.User.Id = Environment.UserName;
    tc.Context.Session.Id = Guid.NewGuid().ToString();
    tc.Context.Device.OperatingSystem = Environment.OSVersion.ToString();
    tc.TrackTrace("some data....");
    tc.Flush(); // only for desktop apps
