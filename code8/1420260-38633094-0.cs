    public class SPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.FillRoundedRectangle(new SolidBrush(Color.White), 10, 10, this.Width - 40, this.Height - 60, 10);
			SolidBrush brush = new SolidBrush(
				Color.White
				);
			g.FillRoundedRectangle(brush, 12, 12, this.Width - 44, this.Height - 64, 10);
			g.DrawRoundedRectangle(new Pen(ControlPaint.Light(Color.White, 0.00f)), 12, 12, this.Width - 44, this.Height - 64, 10);
			g.FillRoundedRectangle(new SolidBrush(Color.White), 12, 12 + ((this.Height - 64) / 2), this.Width - 44, (this.Height - 64)/2, 10);
        }
    }
