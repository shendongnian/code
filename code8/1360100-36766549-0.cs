    private void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
    {
        if (e.IsGetData && e.Column.FieldName == "PILIH")
        {
            var val = Convert.ToString(gridView2.GetRowCellValue(e.RowHandle, "ISJAWAB"));
            if (val == "1")
            {
                e.Value = true;
            }
        }
    }     
