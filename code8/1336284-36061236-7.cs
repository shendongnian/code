    private void grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        e.Paint(e.ClipBounds, DataGridViewPaintParts.All &
                            ~(DataGridViewPaintParts.ErrorIcon));
        if (!String.IsNullOrEmpty(e.ErrorText))
        {
            GraphicsContainer container = e.Graphics.BeginContainer();
            e.Graphics.TranslateTransform(e.CellStyle.Padding.Right, 0);
            e.Paint(e.CellBounds, DataGridViewPaintParts.ErrorIcon);
            e.Graphics.EndContainer(container);
        }
        e.Handled = true;
    }
