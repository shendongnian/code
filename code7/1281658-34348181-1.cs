	using (SolidBrush greenBrush = new SolidBrush(Color.Green))
	using (SolidBrush darkGreenBrush = new SolidBrush(Color.DarkGreen)) {
		g.FillRectangle(greenBrush , (float)ran1, (float)0, 3, pictureBox1.Height);
		g.FillRectangle(darkGreenBrush, (float)ran2, (float)0, 3, pictureBox1.Height);
	}
