	Bitmap bmp = new Bitmap(200, 200);
	using (Graphics g = Graphics.FromImage(bmp)) {
		g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
		string LongText = "This is a really long text that should be automatically wrapped to a certain rectangle.";
		Rectangle DestinationRectangle = new Rectangle(10, 10, 100, 150);
		g.DrawRectangle(Pens.Red, DestinationRectangle);
		using (StringFormat sf = new StringFormat()) {
			g.DrawString(LongText, new Font("Arial", 9), Brushes.Black, DestinationRectangle, sf);
		}
	}
	PictureBox1.Image = bmp;
