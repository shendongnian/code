    private ICollectionView _collectionView;
    private ICollectionView _CollectionView {
        get { return _collectionView
            ?? (_collectionView = CollectionViewSource.GetDefaultView(SelectedItems)); }
    }
    public ICollectionView FilteredItems { 
        get { _CollecitionView.Filter(...); }
    }
    <ListBox ItemsSource={"Binding FilteredSelectedItems"} />
