    try
    {
        ServiceRuntime.RegisterServiceAsync("RunSetManagerServiceType",
            context => new RunSetManagerService(context)).GetAwaiter().GetResult();
        ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(Stateless1).Name);
        // Prevents this host process from terminating so services keep running.
        Thread.Sleep(Timeout.Infinite);
    }
    catch (Exception e)
    {
        ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
        throw;
    }
