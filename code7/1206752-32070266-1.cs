    private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
    {
        if (e.Column.FieldName == "Colors")
            try
            {
                e.Appearance.BackColor = Color.FromName(e.CellValue.ToString());
                e.Appearance.Options.UseBackColor = true;
            }
            catch { }
    }
