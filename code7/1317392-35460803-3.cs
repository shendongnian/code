    HostingEnvironment.QueueBackgroundWorkItem(token =>
    {
        try
        {
            _logger.Debug("Executing queued background work item");
            using (HostingEnvironment.Impersonate(callingPrincipal.Identity))
            {
                using (var scope = DependencyResolver.BeginLifetimeScope())
                {
                    var service = scope.Resolve<T>();
                    action(service);
                }
            }
            // UNCOMMENT - THROWS EXCEPTION
            // Thread.CurrentPrincipal = callingPrincipal;
        }
        catch (Exception ex)
        {
            _logger.Fatal(ex);
        }
        finally
        {
            _logger.Debug("Completed queued background work item");
        }
    });
