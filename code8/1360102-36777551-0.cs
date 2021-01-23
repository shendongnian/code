    private void gridView2_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
    {
        if (e.Column.FieldName == "PILIH")
        {
            var val = Convert.ToString(gridView2.GetRowCellValue(e.RowHandle, "ISJAWAB"));
            if (val == "1")
            {
                gridView2.SetRowCellValue(e.RowHandle, "PILIH", true);
            }
        }
    }
