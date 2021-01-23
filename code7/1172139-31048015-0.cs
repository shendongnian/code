    private void datagrid1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int ColumnIndex = e.Column.DisplayIndex;
            Double amount = Double.Parse(((TextBox)e.EditingElement).Text);
            string col = ((System.Windows.Controls.DataGridBoundColumn)(e.Column)).Binding.Path.Path;
            double val = Double.Parse(e.Row.DataContext.GetType().GetProperty(col).GetValue(e.Row.DataContext, null).ToString());
            Cat1SubTotal += (amount - val);
            GrandTotal += amount;
        }
