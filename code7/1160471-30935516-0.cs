    var dependencyResolver = GlobalHost.DependencyResolver;
    var connectionManager = dependencyResolver.Resolve<IConnectionManager>();
    var hubContext = connectionManager.GetHubContext<TimeEntryHubs.TimeEntrySettingsHub>();
       if (TimeEntryHubs.TimeEntrySettingsHub.Users.Any(f => f.Key == userId))
          {
            var connectionID = TimeEntryHubs.TimeEntrySettingsHub.Users.Where(f => f.Key == userId).Single().Value;
            hubContext.Clients.Client(connectionID).ApplyChangedSettings();
          }
