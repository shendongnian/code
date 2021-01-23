    private void TransitionTable_CellPainting(object sender, 
                                              DataGridViewCellPaintingEventArgs e)
    {
        using (Brush b = new SolidBrush(TransitionTable.DefaultCellStyle.BackColor))
            e.Graphics.FillRectangle(b, e.CellBounds);
        e.PaintContent(e.ClipBounds);
        if (e.RowIndex == -1)  // column header
        {
            e.Graphics.DrawLine(Pens.Black, 0, e.CellBounds.Bottom - 1, 
                                            e.CellBounds.Right, e.CellBounds.Bottom - 1);
        }
        if (e.ColumnIndex == -1)  // row header (*)
        {
            e.Graphics.DrawLine(Pens.Red, e.CellBounds.Right - 1, 0, 
                                          e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
        }
        e.Handled = true;
    }
