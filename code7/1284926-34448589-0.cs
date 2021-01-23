    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBox cmb = (ComboBox)sender;
        DataGridRow row = (DataGridRow)MyDataGrid.ItemContainerGenerator.ContainerFromItem(cmb.DataContext);
        ((TextBlock)MyDataGrid.Columns[0].GetCellContent(row)).Text = cmb.SelectedIndex.ToString();
    }
