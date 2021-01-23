    private void OnChecked(object sender, RoutedEventArgs e)
    {
        CheckBox checkBox = (CheckBox)e.OriginalSource;
        DataGridRow dataGridRow = VisualTreeHelpers.FindAncestor<DataGridRow>(checkBox);
    
        var produit = dataGridRow.DataContext;
    
        if (checkBox.IsChecked && String.IsNullOrEmpty(produit.oldLibelle)
        {
            // Show message box here...
        }
    
    
        e.Handled = true;
    }
