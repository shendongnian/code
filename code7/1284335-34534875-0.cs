    // In initialization
    myDG.CellEditEnding += myDG_CellEditEnding;
    void myDG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.EditAction == DataGridEditAction.Commit)
        {
            var column = e.Column as DataGridBoundColumn;
            if (column != null)
            {
                var bindingPath = (column.Binding as Binding).Path.Path;
                if (bindingPath == "Col2")
                {
                    int rowIndex = e.Row.GetIndex();
                    var el = e.EditingElement as TextBox;
                    // rowIndex has the row index
                    // bindingPath has the column's binding
                    // el.Text has the new, user-entered value
                }
            }
        }
    }
