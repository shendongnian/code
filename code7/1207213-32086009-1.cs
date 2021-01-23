    public ICollectionView SourceItems {
      get {
        return _sourceItems 
          ?? (_sourceItems = CollectionViewSource.GetDefaultView(_source));
      }
    }
