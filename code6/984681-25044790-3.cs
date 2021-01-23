    public ICollectionView ActiveTypes 
    {
        get
        {
            if (_activeTypes == null)
            {
                _activeTypes = CollectionViewSource.GetDefaultView(myExtendedTypes);
                _activeTypes.Filter = (type) => (type as ExtendedType).IsActive;
            }
            return _activeTypes;
        }
    }
