     private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {            
            System.Windows.Controls.ContextMenu cm = BrowseButtonContext as System.Windows.Controls.ContextMenu;
            cm.PlacementTarget = sender as System.Windows.Controls.Button;
            cm.IsOpen = true;            
        }
