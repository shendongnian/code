	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		using (BufferedGraphicsContext context = new BufferedGraphicsContext())
		using (BufferedGraphics buffer = context.Allocate(e.Graphics, new Rectangle(0, 0, 120, 120)))
		{
            // Create a bitmap with just a blue line on it
			Bitmap bmp = new Bitmap(100, 100, PixelFormat.Format32bppArgb);
			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.DrawLine(Pens.Blue, 0, 0, 100, 100);
			}
            // Fill a red square
			buffer.Graphics.FillRectangle(Brushes.Red, 5, 5, 110, 110);
            // Draw the blue-line image over the red square area
			buffer.Graphics.DrawImage(bmp, 10, 10);
            // Render the buffer to the underlying graphics
			buffer.Render(e.Graphics);
		}
	}
