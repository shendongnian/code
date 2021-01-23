    DataGridService.Focus();
                DataGridRow row = (DataGridRow)DataGridService.ItemContainerGenerator.ContainerFromIndex(100);
                object item = DataGridService.Items[100];
                DataGridService.SelectedItem = item;
    
    
                DataGridService.ScrollIntoView(item);
                row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
