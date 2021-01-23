    private void CollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs e)
    {
        Inlines.AddRange(e.NewItems);
    }
    private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue == null) return;
        var textBlock = (BindableTextBlock)sender;
        textBlock.InlineList.CollectionChanged += textBlock.CollectionChangedHandler;
    }
