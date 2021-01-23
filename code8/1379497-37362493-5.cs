	private class Cell
	{
		public Color Color { get; set; }
		public Rectangle Rectangle { get; set; }
	}
	private Cell[] cellsGrid;
	private Random rnd = new Random();
	// generate 100k random cells
	private void btnNextStep_Click(object sender, EventArgs e)
	{
		this.cellsGrid = new Cell[100000];
		for (int i = 0; i < this.cellsGrid.Length; i++)
		{
			this.cellsGrid[i] = new Cell()
			{
				Color = Color.FromArgb(rnd.Next()),
				Rectangle = new Rectangle(rnd.Next(0, pictureBox1.Width), rnd.Next(0, pictureBox1.Height), rnd.Next(1, 5), rnd.Next(1, 5))
			};
		}
		this.DrawCells();
	}
	// draw them and measure time taken
	private void DrawCells()
	{
		var start = DateTime.Now;
		var bmp = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
		using (var g = Graphics.FromImage(bmp))
		using (var p = new Pen(Color.Black))
		using (var b = new SolidBrush(Color.Black))
		{
			for (int i = 0; i < this.cellsGrid.Length; i++)
			{
				b.Color = this.cellsGrid[i].Color;
				g.FillRectangle(b, this.cellsGrid[i].Rectangle);
				p.Color = this.cellsGrid[i].Color;
				g.DrawRectangle(p, this.cellsGrid[i].Rectangle);
			}
		}
		this.pictureBox1.Image = bmp;
		MessageBox.Show((DateTime.Now - start).TotalSeconds.ToString());
	}
