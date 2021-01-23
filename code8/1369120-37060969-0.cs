     grid.DataContext = ObservableCollection.OrderByDescending(y => y.ItemA.IndexOf("LOVEU")); 
     private void grid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            ListCollectionView view = (ListCollectionView)(CollectionViewSource.GetDefaultView(this.DataContext));
            if (e.Column != null && e.Column.CanUserSort == true && e.Column.Header.ToString() != "ItemA")
            {
                var dgSender = (DataGrid)sender;
                var cView = CollectionViewSource.GetDefaultView(dgSender.ItemsSource);
                cView.SortDescriptions.Clear();
                cView.SortDescriptions.Add(new SortDescription("ItemA", ListSortDirection.Descending));
                
                if (e.Column.SortDirection == ListSortDirection.Ascending)
                {   
                    e.Column.SortDirection = ListSortDirection.Descending;
                    cView.SortDescriptions.Add(new SortDescription(e.Column.Header.ToString(), ListSortDirection.Descending));
                }
                else
                {   
                    e.Column.SortDirection = ListSortDirection.Ascending;
                    cView.SortDescriptions.Add(new SortDescription(e.Column.Header.ToString(), ListSortDirection.Ascending));
                }
                e.Handled = true;
            }
        }
