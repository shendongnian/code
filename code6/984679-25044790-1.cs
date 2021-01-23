    public ICollectionView ActiveTypes 
    {
         if (_activeTypes == null)
         {
             _activeTypes = CollectionView.GetDefaultView(myExtendedTypes);
             _activeTypes.Filter = (type) => type.IsActive;
         }
         return _activeTypes;
    }
