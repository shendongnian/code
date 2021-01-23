    private void cmbAddExtras_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = cmbAddExtras.SelectedItem;
    
        if (item != null)
        {
            dgAddExtras.Items.Add(item);
            cmbAddExtras.Remove(item);
        }
    }
