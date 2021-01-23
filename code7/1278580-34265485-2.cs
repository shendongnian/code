    <DataGrid.Resources>
         <Style TargetType="DataGridCell">
             <EventSetter Event="DataGridCell.Loaded" Handler="DataGridCell_Load"/>
         </Style>
    </DataGrid.Resources>
    private void DataGridCell_Load(object sender, RoutedEventArgs e)
            {
                DataGridCell cell = sender as DataGridCell;
    
                if (cell.Column.Header.ToString() == "MyColumn")
                    ((TextBlock)cell.Content).Text = ...do something... ;
    
                /* to get current row and column */
                DataGridColumn col = cell.Column;
                Dgrd2.CurrentCell = new DataGridCellInfo(cell);
                DataGridRow row = (DataGridRow)Dgrd2.ItemContainerGenerator.ContainerFromItem(Dgrd2.CurrentItem);             
            }
