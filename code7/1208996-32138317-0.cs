	Bitmap bmp = new Bitmap(200, 200);
	using (Graphics g = Graphics.FromImage(bmp)) {
		//The individual lines to draw
		string[] lines = {
			"Foo1",
			"Foo2",
			"Foo3"
		};
		int y = 1; //The starting Y-coordinate
		int spacing = 10; //The space between each line in pixels
		for (i = 0; i <= lines.Count - 1; i++) {
			g.DrawString(lines[i], this.Font, Brushes.Black, 1, y);
			//Increment the coordinate after drawing each line
			y += Convert.ToInt32(g.MeasureString(lines[i], this.Font).Height) + spacing;
		}
	}
	PictureBox1.Image = bmp;
