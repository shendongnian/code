    private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = (MultiSelectComboBox)d;
        // Since we have to listen for changes to keep items synced, first check if there is an active listener to clean up.
        if (e.OldValue != null)
        {
            ((ObservableCollection<Node>)e.OldValue).CollectionChanged -= OnItemsSource_CollectionChanged;
        }
        // Now initialize with our new source.
        if (e.NewValue != null)
        {
            ((ObservableCollection<Node>)e.NewValue).CollectionChanged += OnItemsSource_CollectionChanged;
            control.DisplayInControl();
        }
    }
    private void OnItemsSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        DisplayInControl();
    }
