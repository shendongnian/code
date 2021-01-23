    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        DataGrid dataGrid = YOURDATAGRIDNAME;
        DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
        DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
        string CellValue = ((TextBlock)RowAndColumn.Content).Text;
        MessageBox.Show(CellValue);
    }
