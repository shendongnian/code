    private void PublishSpringChange(object sender, NotifyCollectionChangedEventArgs e)
    {
        foreach (INotifyPropertyChanged added in e.NewItems)
        {
            added.PropertyChanged += SpringDataOnPropertyChanged;
        }
        foreach (INotifyPropertyChanged removed in e.OldItems)
        {
            removed.PropertyChanged -= SpringDataOnPropertyChanged;
        }
    }
    private SpringDataOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
    {
        //your code here
    }
