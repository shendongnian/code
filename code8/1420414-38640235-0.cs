	class MyDataGridView : DataGridView
	{
		protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
		{
			e.PaintCells(e.RowBounds, e.PaintParts);
			e.PaintHeader(true);
			e.Handled = true;
		}
		protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
		{
			base.OnCellPainting(e);
		}
	}
