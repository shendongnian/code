    private static void OnMyProperty(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        UC control = d as UC;
        if (e.NewValue is INotifyCollectionChanged)
        {
            (e.NewValue as INotifyCollectionChanged).CollectionChanged +=
                (s, ecc) => {
                    //  Do stuff with UC and ecc.NewItems, ecc.OldItems, etc.
                };
        }
    }
