	class LabelWithLine : Label
	{
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.DrawLine(Pens.Black, 0, 0, this.Width, 0);
		}
	}
