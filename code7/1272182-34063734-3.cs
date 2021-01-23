	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		using (BufferedGraphicsContext context = new BufferedGraphicsContext())
		using (BufferedGraphics buffer = context.Allocate(e.Graphics, new Rectangle(0, 0, 115, 115)))
		{
			Bitmap bmp = new Bitmap(100, 100, PixelFormat.Format32bppArgb);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.DrawLine(Pens.Blue, 0, 0, 100, 100);
			}
			buffer.Graphics.FillRectangle(Brushes.Red, 0, 0, 115, 115);
			buffer.Graphics.DrawImage(bmp, 10, 10);
			buffer.Render(e.Graphics);
		}
	}
    
