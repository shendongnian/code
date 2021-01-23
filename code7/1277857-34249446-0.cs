        private void Details_Click(object sender, RoutedEventArgs e)
        {
           DataGridRow row = (DataGridRow)Dgrd1.ItemContainerGenerator.ContainerFromItem(Dgrd1.SelectedItem);
    
           if (row.DetailsVisibility == System.Windows.Visibility.Visible)
               row.DetailsVisibility = System.Windows.Visibility.Collapsed;
           else
               row.DetailsVisibility = System.Windows.Visibility.Visible;
        }
