    public ObservableCollection<TraceDataItem> FilteredData
    {
        get 
        {
            return new ObservableCollection<TraceDataItem>(YourUnfilteredCollection.Where(
                i => MeetsFilterRequirements(i))); 
        }
    }
    private bool MeetsFilterRequirements(TraceDataItem item)
    {
        return item.SomeProperty == someValue || item is SomeType;
    }
