    private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
    {
        var dg = sender as DataGrid;
        var pis = e.Row.DataContext.GetType().GetProperties();
        foreach (var pi in pis)
        {
            // Check if this property already has a column in the datagrid
            string name = pi.Name;
            var q = dg.Columns.Where(_ => _.SortMemberPath == name);
            if (!q.Any())
            {
                // No column matches, so add one
                DataGridTextColumn c = new DataGridTextColumn();
                c.Header = name;
                c.SortMemberPath = name;
                System.Windows.Data.Binding b = new Binding(name);
                c.Binding = b;
    
                // All columns don't apply to all items in the list
                // So, we need to disable the cells that aren't applicable
                // We'll use a converter on the IsEnabled property of the cell
                b = new Binding();
                b.Converter = new ReadOnlyConverter();
                b.ConverterParameter = name;
    
                // Can't apply it directly, so we have to make a style that applies it
                Style s = new Style(typeof(DataGridCell));
                s.Setters.Add(new Setter(DataGridCell.IsEnabledProperty, b));
                // Add a trigger to the style to color the background when disabled
                var dt = new DataTrigger() { Binding = b, Value = false };
                dt.Setters.Add(new Setter(DataGridCell.BackgroundProperty, Brushes.Silver));
                s.Triggers.Add(dt);
                c.CellStyle = s;
    
                // Add the column to the datagrid
                dg.Columns.Add(c);
            }
        }
    }
