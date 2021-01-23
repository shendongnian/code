    public static readonly DependencyProperty FilterdResourcesProperty =
            DependencyProperty.Register("SelectedFilterdResources",
                typeof (ObservableCollection<ResourceItem>),
                typeof (ResourceSelectionBoxLable),
                new PropertyMetadata(new ObservableCollection<ResourceItem>(),
                    CaptionCollectionChanged));
    private static void CaptionCollectionChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs args)
        {
            var collection = args.NewValue as INotifyCollectionChanged;
            if (collection != null)
            {
                var sender = d as ResourceSelectionBoxLable;
                if (sender != null)
                {
                    collection.CollectionChanged += sender.BoundItems_CollectionChanged;
                }                
            }
        }
        private void BoundItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Do your control logic here.
        }
