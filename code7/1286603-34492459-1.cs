    private void CaptureForm()
    {
        var bmp = new Bitmap(MainForm.Width, MainForm.Height, PixelFormat.Format32bppArgb);
        var g = Graphics.FromImage(bmp);
        g.CopyFromScreen(MainForm.Location.X, MainForm.Location.Y, 0, 0,
                        MainForm.Size, CopyPixelOperation.SourceCopy);
			
        //Clipboard.SetImage(bmp);
		pictureBox1.Image = bmp;
	}
