    private void gridView1_CellValueChanging(object sender, CellValueChangedEventArgs e)
    {
        if (e.Column.FieldName == "IsOrdered")
        {
            gridView1.SetRowCellValue(e.RowHandle, e.Column, e.Value);
            //Do your other staff here.               
        }
    }
