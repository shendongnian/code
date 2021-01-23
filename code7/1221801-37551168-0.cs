    //Adding your viewModel to your ObservableCollection<> TabControlViews
    TabControlViews.Add(_viewModelToAdd);
    ICollectionView collectionView = CollectionViewSource.GetDefaultView(TabControlViews);
    if (collectionView != null)
        collectionView.MoveCurrentTo(_viewModelToAdd);
