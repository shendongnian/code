    private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
            {
                if (sender != null)
                {
                    DataGrid grid = sender as DataGrid;
                    if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                    {
                        DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                        YourClass obj = dgr.Item as YourClass;
                        this.selectedIndex = grid.SelectedIndex;
                        int id = obj.ID;
                    }
                }
            }
