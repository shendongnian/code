    private void gridView2_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
    {
        if (e.IsGetData && e.Column.FieldName == "PILIH")
        {
            var row = (DataRow) e.Row;
            var val = Convert.ToString(row["ISJAWAB"]));
            if (val == "1")
            {
                e.Value = true;
            }
        }
    }     
