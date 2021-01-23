          private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
            {
                GridViewColumnHeader colHeader = (GridViewColumnHeader)e.OriginalSource;
                string colName = colHeader.Content.ToString();
    
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LstView.ItemsSource);
                view.SortDescriptions.Add(new SortDescription(colName, ListSortDirection.Ascending));
    
                view.Refresh();
            }
