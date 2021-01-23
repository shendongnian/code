    private ICollectionView songsView;
    public ICollectionView SongsView
    {
        get
        {
            if (songsView== null)
            {
                songsView= CollectionViewSource.GetDefaultView(Songs);
                songsView.SortDescriptions.Add(new SortDescription("Name",
                                                   ListSortDirection.Ascending));
            }
            return songsView;
        }
    }
