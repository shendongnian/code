    var sink = new VBProjectsEventsSink();
    var connectionPointContainer = (IConnectionPointContainer)_vbe.VBProjects;
    Guid interfaceId = typeof (_dispVBProjectsEvents).GUID;
    connectionPointContainer.FindConnectionPoint(ref interfaceId, out _projectsEventsConnectionPoint);
    sink.ProjectAdded += sink_ProjectAdded;
    sink.ProjectRemoved += sink_ProjectRemoved;
    sink.ProjectActivated += sink_ProjectActivated;
    sink.ProjectRenamed += sink_ProjectRenamed;
    _projectsEventsConnectionPoint.Advise(sink, out _projectsEventsCookie);
