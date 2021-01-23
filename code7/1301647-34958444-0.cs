    private void button1_Click(object sender, EventArgs e)
	{
		using(Form frm = new Form())
		{
			Panel pnl = new Panel();
			pnl.Paint += delegate (Object snd, PaintEventArgs e2)  {
				Matrix mtx = new Matrix();
				mtx.Translate(pnl.AutoScrollPosition.X, pnl.AutoScrollPosition.Y);
				e2.Graphics.Transform = mtx;
				e2.Graphics.Clear(Color.Black);
				for(int i=0; i <= 125; i++)
					for(int j=0; j <= 125; j++)
						using(Brush b = new SolidBrush(Color.FromArgb(255, 255-i*2, j*2, (i*j) % 255)))
							e2.Graphics.FillRectangle(b, new Rectangle(5+j*20, 5+i*20, 20, 20));
			};
			pnl.AutoScrollMinSize = new Size(126*20+10, 126*20+10);
			pnl.Dock = DockStyle.Fill;
			frm.Controls.Add(pnl);
            frm.Padding = new Padding(25);
			frm.ShowDialog(this);
		}
	}
