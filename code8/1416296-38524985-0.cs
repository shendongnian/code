    /// <summary>
    /// DI registrations for loggers.
    /// </summary>
    public class LoggersModule : IModule
    {
        public void Configure(IComponentRegistry componentRegistry)
        {
            componentRegistry.Registered += (sender, e) =>
                                     e.ComponentRegistration.Preparing += OnComponentPreparing;
        }
        private static void OnComponentPreparing(object sender, PreparingEventArgs e)
        {
            var t = e.Component.Activator.LimitType;
            e.Parameters = e.Parameters.Union(new[] 
            { 
                new ResolvedParameter(
                                                  (p, i) => p.ParameterType == typeof(ILogger), 
                                                  (p, i) => LoggerFactory.GetLoggerForClass(t))
            });
        }
    }
