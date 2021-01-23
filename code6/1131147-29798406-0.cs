    DataGrid dataGrid = sender as DataGrid;
    DataGridRow row = (DataGridRow)datagridname
        .ItemContainerGenerator
        .ContainerFromIndex(datagridname.SelectedIndex);
    DataGridCell RowColumn = datagridname.Columns[0].GetCellContent(row).Parent as DataGridCell;
    string ContentOfCell = ((TextBlock)RowColumn.Content).Text;
