    private void Dgrd_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
            {          
                foreach(DataGridCellInfo info in e.AddedCells)
                {
                    if (info.Item is Student && ((Student)info.Item).Enabled == false)                    
                        ((DataGridRow)Dgrd.ItemContainerGenerator.ContainerFromItem(info.Item)).IsSelected = false;                    
                }
            }
