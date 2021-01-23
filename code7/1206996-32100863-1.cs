    protected virtual void OnDataContextChanged(object sender, DependencyPropertyChangedEventHandler args)
    {
        ChangeVisibility();
        INotifyPropertyChanged context;
        // Cleanup any handler attached to a previous data context object.
        context = e.OldValue as INotifyPropertyChanged;
        if (context != null)
            context.PropertyChanged -= DataContext_PropertyChanged;
        // Listen for any further changes which effect visibility.
        context = e.NewValue as INotifyPropertyChanged;
        if (context != null)
            context.PropertyChanged += DataContext_PropertyChanged;
    }
    private void DataContext_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "MyTargetProperty")
        {
            ChangeVisibility();
        }
    }
