     private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
     {
         CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LstView.ItemsSource);
         view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
    
         view.Refresh();
     }
