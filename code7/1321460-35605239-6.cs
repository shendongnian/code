    public void Dispose()
    {
        _projectsEventsConnectionPoint.Unadvise(_projectsEventsCookie);
        foreach (var item in _componentsEventsConnectionPoints)
        {
            item.Value.Item1.Unadvise(item.Value.Item2);
        }
    }
