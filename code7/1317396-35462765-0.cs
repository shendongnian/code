    public void Run<T>(Action<T> action)
    {
        _logger.Debug("Queueing background work item");
        var principal = new ClaimsPrincipal(Thread.CurrentPrincipal);
        HostingEnvironment.QueueBackgroundWorkItem(token =>
        {
            try
            {
                Thread.CurrentPrincipal = principal;
                _logger.Debug("Executing queued background work item");
                using (var scope = DependencyResolver.BeginLifetimeScope())
                {
                    var service = scope.Resolve<T>();
                    action(service);
                }
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
    }
