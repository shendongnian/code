    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == 2 && e.RowIndex >= 0)
        {
            // use your own code here...
            string val = ((int)e.Value).ToString("00000000");
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.PaintBackground(e.CellBounds, false);
            for (int i = 0; i < count; i++)
                using (SolidBrush brush = new   // ..and here!!!
                       SolidBrush(colors[Convert.ToInt16(val[i].ToString())]))
                    e.Graphics.FillEllipse(brush, 
                        e.CellBounds.X + i * 12 + 6, e.CellBounds.Y + 5 , 11, 11);
            e.Handled = true;
        }
    }
