    var displayName = ServiceController.GetServices()
                .Where(s => s.ServiceName == "MpsSvc")
                .Select(s => s.DisplayName)
                .ToList()[0];
    ServiceController sc = new ServiceController(displayName);
