    public ObservableCollection<TraceDataItem> FilteredData
    {
        get { return YourUnfilteredCollection.Where(i => MeetsFilterRequirements(i)); }
    }
    private bool MeetsFilterRequirements(TraceDataItem item)
    {
        return item.SomeProperty == someValue || item is SomeType;
    }
