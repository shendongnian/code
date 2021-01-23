    static private List<Tuple<string, string>> _editedCells = new List<Tuple<string,string>>();
    static void EditValue(object sender)
    {
        TextEdit edit = (sender as TextEdit);
        if (edit == null || edit.DataContext as CellsAreaItem == null) return;
        CellsAreaItem item = edit.DataContext as CellsAreaItem;
        decimal newValue;
        decimal oldValue;
        if (edit.EditValue != null && decimal.TryParse(edit.EditValue.ToString(), out newValue))
        {
            if (item.Value == null || !decimal.TryParse(item.Value.ToString(), out oldValue))
                return;
            PivotGridControl pivotGrid = FindParentPivotGrid((DependencyObject)sender);
            if (pivotGrid == null)
                return;
            PivotGridField fieldExtendedPrice = pivotGrid.Fields["amount"];
            PivotDrillDownDataSource ds = pivotGrid.CreateDrillDownDataSource(item.ColumnIndex, item.RowIndex);
            decimal difference = newValue - oldValue;
            decimal factor = (difference == newValue) ? (difference / ds.RowCount) : (difference / oldValue);
            for (int i = 0; i < ds.RowCount; i++)
            {
                decimal value = Convert.ToDecimal(ds[i][fieldExtendedPrice]);
                ds[i][fieldExtendedPrice] = (double)((value == 0m) ? factor : value * (1m + factor));//(double)newValue; 
            }
            
            //Store the fields values.
            var cellInfo = PivotGridControl1.GetCellInfo(item.ColumnIndex, item.RowIndex);
            string itemValue = (string)cellInfo.GetFieldValue(PivotGridControl1.Fields["item"]);
            string nameValue = (string)cellInfo.GetFieldValue(PivotGridControl1.Fields["name"]);
            var editedCell = new Tuple<string, string>(itemValue, nameValue);
            if (!_editedCells.Contains(editedCell))
                _editedCells.Add(editedCell);
            pivotGrid.RefreshData();
        }
    }    
    private void PivotGridControl1_CustomCellAppearance(object sender, PivotCustomCellAppearanceEventArgs e)
    {
        //Check for field values.
        string itemValue = (string)e.GetFieldValue(PivotGridControl1.Fields["item"]);
        string nameValue = (string)e.GetFieldValue(PivotGridControl1.Fields["name"]);
        var editedCell = new Tuple<string, string>(itemValue, nameValue);
        if (_editedCells.Contains(editedCell))
            e.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
    }
