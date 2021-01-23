	private void timer1_Tick(object sender, EventArgs e)
	{
		var path = sc.CaptureWindowToMemory();
		pictureBox1.ImageLocation = path;
		
		countimages += 1;
	}
		
	public string CaptureWindowToMemory()
	{
		var name = "foo.png";
		using (var img = CaptureWindow(handle))
		using (var currentBitmap = new Bitmap(img))
			currentBitmap.Save(name, System.Drawing.Imaging.ImageFormat.Png);
		return name;
	}
