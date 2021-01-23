	Bitmap bmp;
	Graphics gOff;
	void Initialize() {
		bmp = new Bitmap(width, height);
		gOff = bmp.FromImage();
	}
	private void OnPaint(object sender, System.Windows.Forms.PaintEventArgs e) {
		e.Graphics.DrawImage(bmp, 0, 0);
	}
	void RenderParticles() {
		foreach (var particle in Particles)
			RotateParticle(gOff, ...);
	}
