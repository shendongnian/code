    if (dTable != null) // table is a DataTable
    {
      foreach (DataColumn col in dTable.Columns)
      {
        dataGrid.Columns.Add(
          new DataGridTextColumn
          {
            Header = col.ColumnName,
            Binding = new Binding(string.Format("[{0}]", col.ColumnName))
          });
      }
    
      DataGridSpil.DataContext = table;
    }
