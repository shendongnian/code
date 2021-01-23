    Private Sub ItemsList_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles ItemsList.CellPainting
            If ItemsList.Columns(e.ColumnIndex).Name = "iconCol" And e.RowIndex >= 0 Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Width, e.CellBounds.Height)
            End If
