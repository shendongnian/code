	Bitmap backgroundBitmap = new Bitmap("background");
	Bitmap tankBitmap = new Bitmap("tank");
	private void Form1_Paint(object sender, PaintEventArgs e)
	{
		e.Graphics.DrawImage(backgroundBitmap, 0, 0);
		e.Graphics.DrawImage(tankBitmap, 30, 30);
	}
	private void timer1_Tick(object sender, EventArgs e)
	{
		this.Invalidate(); //trigger Form1_Paint to draw next frame
	}
