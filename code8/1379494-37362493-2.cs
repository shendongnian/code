    // generate some random rects
	for (int i = 0; i < 5000; i++)
	{
		list.Add(new Rectangle(rnd.Next(0, pictureBox1.Width), rnd.Next(0, pictureBox1.Height), rnd.Next(1, pictureBox1.Width), rnd.Next(1, pictureBox1.Height)));
	}
	var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
	using (var g = Graphics.FromImage(bmp))
	using (var path = new System.Drawing.Drawing2D.GraphicsPath())
	{
		path.AddRectangles(list.ToArray());
		g.FillPath(Brushes.Red, path);
		g.DrawPath(Pens.Black, path);
	}
	pictureBox1.Image = bmp;
