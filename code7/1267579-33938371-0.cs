    this.serviceInstaller.ServicesDependedOn = SqlServerServiceHelper.GetInstances().Select(x => x.ServiceName).ToArray();
            
            
    public static ServiceController[] GetInstances()
    {
         ServiceController[] services = ServiceController.GetServices().Where(x => x.ServiceName.Contains("SQL")).ToArray();
         var servicesToRemove = services.Where(x => x.DisplayName.Contains("Agent") ||
                                               x.DisplayName.Contains("Browser") ||
                                               x.DisplayName.Contains("VSS") ||
                                               x.DisplayName.Contains("Active")).ToArray();
         return services.Except(servicesToRemove).ToArray();
    }
