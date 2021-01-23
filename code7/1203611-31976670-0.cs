    private static void OnComponentPreparing(object sender, PreparingEventArgs e)
    {
        var t = e.Component.Target.Activator.LimitType;
        e.Parameters = e.Parameters.Union(
        new[]
        {
          new ResolvedParameter((p, i) => p.ParameterType == typeof(ILog), 
                                (p, i) => LogManager.GetLogger(t)),
        });
    }
