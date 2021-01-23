    protected override void OnApplicationStarted(object sender, EventArgs e)
    {
        var ignored = MiniProfiler.Settings.IgnoredPaths.ToList();
        ignored.Add("/signalr/");        
        ignored.Add("/idle/verify");
        ignored.Add("/idle/interaction");
        ignored.Add("/umbraco/ping");
        MiniProfiler.Settings.IgnoredPaths = ignored.ToArray();
        // Setup profiler for Controllers via a Global ActionFilter
        GlobalFilters.Filters.Add(new ProfilingActionFilter());
        // initialize automatic view profiling
        var copy = ViewEngines.Engines.ToList();
        ViewEngines.Engines.Clear();
        foreach (var item in copy)
        {
            ViewEngines.Engines.Add(new ProfilingViewEngine(item));
        }
    }
