	class MyDataGridView : DataGridView
	{
		protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
		{
			e.Handled = true;
		}
		protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
		{
			base.OnCellPainting(e);
		}
	}
