    private void Dgrd_Sorting(object sender, DataGridSortingEventArgs e)
            {            
                DataGridColumn col = e.Column;
                if (col.Header.ToString() == "FileName")
                {
                    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(Dgrd.ItemsSource);
                    view.SortDescriptions.Add(new System.ComponentModel.SortDescription("FileName", System.ComponentModel.ListSortDirection.Ascending));
                    view.SortDescriptions.Add(new System.ComponentModel.SortDescription("CreatedBy", System.ComponentModel.ListSortDirection.Ascending));
                    view.Refresh();
    
                    e.Handled = true;
                }
                else
                    e.Handled = true;
            }
