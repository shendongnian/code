    private void Sort(object sender, RoutedEventArgs args)
    {
        BlogPosts posts = (BlogPosts)(this.Resources["posts"]);
        ListCollectionView lcv = (ListCollectionView)(CollectionViewSource.GetDefaultView(posts));
        lcv.CustomSort = new SortPosts();
    }
