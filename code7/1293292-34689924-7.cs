     private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
     {
         string colName = ((TextBlock)sender).Text.ToString();
         CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LstView.ItemsSource);
         view.SortDescriptions.Add(new SortDescription(colName, ListSortDirection.Ascending));
    
         view.Refresh();
     }
