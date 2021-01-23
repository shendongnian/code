    private void gridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
    {
        if (e.Column.FieldName == "Colors")
            try
            {
                var currentColor = e.Appearance.ForeColor;
                var currentUseBackColor = e.Appearance.Options.UseForeColor;
                e.Appearance.BackColor = Color.FromName(e.CellValue.ToString());
                e.Appearance.Options.UseBackColor = true;
                e.DefaultDraw();
                e.Appearance.BackColor = currentColor;
                e.Appearance.Options.UseBackColor = currentUseBackColor;
                e.Handled = true;
            }
            catch { }
    }
