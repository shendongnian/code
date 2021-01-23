    protected virtual void OnDataContextChanged(object sender, EventArgs args)
    {
        ChangeVisibility();
        // Listen for any further changes which effect visibility.
        INotifyPropertyChanged context = ((FrameworkElement)sender).DataContext as INotifyPropertyChanged;
        context.PropertyChanged += (s, e) => ChangeVisibility();
    }
