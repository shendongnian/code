    void service_GetObjectCompleted(object sender, GetObjectCompletedEventArgs e)
    {
        if (e.Result.Count != 0)
        {
            PagedCollectionView pagingCollection = new PagedCollectionView(e.Result.Product);
            pgrProductGrids.Source = pagingCollection;
            grdProductGrid.ItemsSource = pagingCollection;
        }
    }
