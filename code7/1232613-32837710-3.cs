    <dxpg:PivotGridControl.FieldCellTemplate>
        <DataTemplate>
            <dxe:PopupCalcEdit
                EditMode="InplaceInactive"
                EditValue="{Binding Value, Mode=OneWay}"
                MouseDown="PopupCalcEdit_MouseDown"
                LostFocus="PopupCalcEdit_LostFocus"
            />
        </DataTemplate>
    </dxpg:PivotGridControl.FieldCellTemplate>
<!>
    private void PopupCalcEdit_MouseDown(object sender, MouseButtonEventArgs e)
    {
        var calcEdit = sender as PopupCalcEdit;
        if (calcEdit == null)
            return;
        calcEdit.EditMode = EditMode.InplaceActive;
    }
    private void PopupCalcEdit_LostFocus(object sender, RoutedEventArgs e)
    {
        var calcEdit = sender as PopupCalcEdit;
        if (calcEdit == null && calcEdit.EditMode != EditMode.InplaceActive)
            return;
        var cellsArea = calcEdit.DataContext as CellsAreaItem;
        if (cellsArea == null)
            return;
        var dataTable = (DataTable)PivotGridControl.DataSource;
        var drillSource = PivotGridControl.CreateDrillDownDataSource(cellsArea.ColumnIndex, cellsArea.RowIndex);
        if (drillSource.RowCount > 0)
        {
            int id = (int)drillSource.GetValue(0, "ID"); //Change only the first row in drilled rows.
            dataTable.Rows.Find(id)["amount"] = calcEdit.EditValue;
        }
        else
        {
            var cellInfo = PivotGridControl.GetCellInfo(cellsArea.ColumnIndex, cellsArea.RowIndex);
            object itemValue = cellInfo.GetFieldValue(PivotGridControl.Fields["item"]);
            object nameValue = cellInfo.GetFieldValue(PivotGridControl.Fields["name"]);
            var row = dataTable.NewRow();
            row["item"] = itemValue;
            row["name"] = nameValue;
            row["amount"] = calcEdit.EditValue;
            dataTable.Rows.Add(row);
        }
        calcEdit.EditMode = EditMode.InplaceInactive;
        PivotGridControl.ReloadData();
    }
