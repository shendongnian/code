    class GridLineTextBox : TextBox
	{
		public GridLineTextBox()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			var y = 0f;
			var lineHeight = e.Graphics.MeasureString("W", Font).Height;
			while (y < e.ClipRectangle.Height)
			{
				y += lineHeight;
				e.Graphics.DrawLine(System.Drawing.Pens.Aqua, new PointF(0, y), new PointF(e.ClipRectangle.Width, y));
			}
		}
	}
