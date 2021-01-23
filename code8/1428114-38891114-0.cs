    DataGridTextColumn column1 = new DataGridTextColumn();
    column1.Header = myTable.Columns[0].Caption;
    column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
    column1.Binding = new Binding("column1_name");
    DataGridTextColumn column1 = new DataGridTextColumn();
    column1.Header = myTable.Columns[1].Caption;
    column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
    column1.Binding = new Binding("column2_name");
        
    dataGrid.Columns.Add(column1);
    dataGrid.Columns.Add(column2);
