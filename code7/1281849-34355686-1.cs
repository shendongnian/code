	private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
	{
		// Don't paint focused/selected rows
		if ((e.State & DataGridViewElementStates.Selected) ==
					DataGridViewElementStates.Selected)
			return;
		// This informs the event that we don't want it to paint the background, we'll take 
		// care of it instead.
		e.PaintParts &= ~DataGridViewPaintParts.Background;
		// Calculate row rectangle (based off the MSDN example)
		var rowBounds = new Rectangle(
			dgv.RowHeadersWidth, e.RowBounds.Top,
			dgv.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - dgv.HorizontalScrollingOffset + 1,
			e.RowBounds.Height);
		// Paint row headers, for some reason they are part of the Background.
		e.PaintHeader(true);
		// Now custom-paint the row background
		using (Brush backBrush = new SolidBrush(Color.NavajoWhite))
		{
			if (e.RowIndex % 2 != 0)
				// If RowIndex is not divisible by 2 then paint custom color
				e.Graphics.FillRectangle(backBrush, rowBounds);
			else
				// Otherwise just let the grid paint the row
				e.PaintCells(rowBounds, DataGridViewPaintParts.Background);
		}
	}
