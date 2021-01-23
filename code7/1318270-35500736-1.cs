    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if ((e.PaintParts & DataGridViewPaintParts.ContentForeground) != 0 && e.FormattedValue != null && e.FormattedValue.ToString().Length > 0
            && e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
            var cellText = e.FormattedValue.ToString();
            for (var fontSize = 8; fontSize <= 72; fontSize++)
            {
                var font = new Font(e.CellStyle.Font.FontFamily, fontSize, e.CellStyle.Font.Style);
                var textSize = TextRenderer.MeasureText(cellText, font);
                //var textSize = e.Graphics.MeasureString(cellText, font); 
                if (textSize.Width > e.CellBounds.Width || textSize.Height > e.CellBounds.Height)
                {
                    font = new Font(e.CellStyle.Font.FontFamily, fontSize - 1, e.CellStyle.Font.Style);
                    e.CellStyle.Font = font;
                    e.Paint(e.ClipBounds, e.PaintParts);
                    e.Handled = true;
                    break;
                }
            }
        }
    
