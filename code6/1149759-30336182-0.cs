    private static void ProcessMessage<T>(T request) where T : IServiceBusRequest
    {
        try
        {
            using (var childScope = _container.BeginLifetimeScope())
            {
                // create and inject things that hold the "context" of the message - user ids, etc
                
                var builder = new ContainerBuilder();
                builder.Register(c => new ServiceRequestContext(request.UserId)).As<IRequestContext>().InstancePerLifetimeScope();
                builder.Update(childScope.ComponentRegistry);
                
                // resolve the component doing the work from the child container explicitly, so all of its dependencies follow
                
                var thing = childScope.Resolve<ThingThatDoesStuff>();
                thing.Do(request);
            }
        }
        catch (Exception ex)
        {
         
        }
    }
