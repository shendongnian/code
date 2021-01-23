    private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var grid = (DataGrid)sender;
        Zeiten selectedItem = (Zeiten)grid.SelectedItem;
        MessageBox.Show("Selected value");
        MessageBox.Show("Linie: " + selectedItem.Linie);
        MessageBox.Show("Von: " + selectedItem.Von);
        MessageBox.Show("Abf: " + selectedItem.Abf);
        MessageBox.Show("Nach: " + selectedItem.Nach);
        MessageBox.Show("Ank: " + selectedItem.Ank);
    }
