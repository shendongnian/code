            private void HandleContentSelection(SelectionChangedEventArgs e)
            {
                if (e == null) return;
    
                var dataGrid = e.Source as DataGrid;
                if (dataGrid == null) return;
    
                #region Update Grid Selection
    
                if (e.AddedItems != null)
                {
                    foreach (var item in e.AddedItems.Cast<IContent>())
                    {
                        if (!item.IsSelected)
                        {
                            item.IsSelected = true;
                        }
                    }
                }
    
                if (e.RemovedItems != null)
                {
                    _contentsToBeUnselected.Clear();
    
                    // Handle Multiple selection
                    // Set hidden items IsSelected property to false
                    if (dataGrid.SelectedItems.Count > 0 && (e.AddedItems == null || e.AddedItems.Count == 0) && e.RemovedItems.Count > 1)
                    {
                        foreach (var content in dataGrid.Items.Cast<IContent>())
                        {
                            if (!dataGrid.SelectedItems.Contains(content))
                            {
                                _contentsToBeUnselected.Add(content);
                            }
                        }
                    }
                    // Handle Unselect All
                    // Set hidden items IsSelected property to false
                    else if (dataGrid.SelectedItems.Count == 0 && (e.AddedItems == null || e.AddedItems.Count == 0))
                    {
                        _contentsToBeUnselected.AddRange(dataGrid.Items.Cast<IContent>());
                    }
                    else
                    {
                        _contentsToBeUnselected.AddRange(e.RemovedItems.Cast<IContent>());
                    }
    
                    foreach (var item in _contentsToBeUnselected)
                    {
                        if (item.IsSelected)
                        {
                            // if bound data item still is selected, fix this
                            item.IsSelected = false;
                        }
                    }
                }
    
                e.Handled = true;
    
                #endregion
    
            }
