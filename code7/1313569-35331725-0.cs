    void service_GetObjectCompleted(object sender, GetObjectCompletedEventArgs e)
    {
        if (e.Result.Productlist.Count != 0)  
        {
            PagedCollectionView pagingCollection = new PagedCollectionView(e.Result.Productlist);
            pgrProductGrids.Source = pagingCollection;
            grdProductGrid.ItemsSource = pagingCollection;
        }
    }
