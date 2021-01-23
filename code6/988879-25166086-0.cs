    public CollectionView songsCollectionView;
    public CollectionView SongsCollectionView
    {
        get 
        {
            if (songsCollectionView == null)
            {
                songsCollectionView  = new CollectionView(Songs);
                songsCollectionView.SortDescriptions.Add(new SortDescription("plNAME", ListSortDirection.Ascending));
            }
            return songsCollectionView;
        }
    }
