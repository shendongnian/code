    private void dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ErrorIcon);
        if (e.ColumnIndex > -1 && e.RowIndex > -1)
        {
            if (this.dgv[e.ColumnIndex, e.RowIndex].ErrorText != string.Empty)
            {
                Rectangle errorRect = this.dgv[e.ColumnIndex, e.RowIndex].ErrorIconBounds;
                errorRect.X += e.CellBounds.X + 30;
                errorRect.Y += e.CellBounds.Y;
                e.Graphics.DrawImage(gridErrorIcon, errorRect);
            }
            e.Handled = true;
        }
    }
    
    internal static Image gridErrorIcon
    {
        get { return Properties.Resources.Error; }
    }
