    void sink_ProjectRemoved(object sender, DispatcherEventArgs<VBProject> e)
    {
        Tuple<IConnectionPoint, int> value;
        if (_componentsEventsConnectionPoints.TryGetValue(e.Item.VBComponents, out value))
        {
            value.Item1.Unadvise(value.Item2);
            _componentsEventsConnectionPoints.Remove(e.Item.VBComponents);
        }
    }
