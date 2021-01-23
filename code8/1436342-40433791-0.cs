    using EnvDTE;
    .
    .
    protected override void Initialize()
    {
        base.Initialize();
        IServiceContainer serviceContainer = this as IServiceContainer;
        dte = serviceContainer.GetService(typeof(SDTE)) as DTE;
        var solutionEvents = dte.Events.SolutionEvents;
        solutionEvents.Opened += OnSolutionOpened;
        var i = dte.Solution.Projects.Count; // Happy days !
    }
