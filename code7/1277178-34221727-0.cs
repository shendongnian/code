		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics gr = e.Graphics;
			int x = 50;
			int y = 50;
			int width = 100;
			int height = 100;
			
			Rectangle rect = new Rectangle(x, y, width/ 2, height / 2);
			Region r = new Region(rect);
			GraphicsPath path = new GraphicsPath();
			path.AddPie(x, y, width, height, 180, 90);
			r.Exclude(path);
			gr.FillRegion(Brushes.Black,r);
		}
