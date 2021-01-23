    string barcode = textBox1.Text;	
	codeImage = GenerateQRCode(barcode, 120);
    // you can make a smaller image as per your need
	rect = new System.Drawing.Rectangle(1080, 530, codeImage.Width, codeImage.Height);
	using (Graphics g = Graphics.FromImage(picEdit))
	{
		g.SmoothingMode = SmoothingMode.AntiAlias;
		g.InterpolationMode = InterpolationMode.HighQualityBicubic;
		g.PixelOffsetMode = PixelOffsetMode.HighQuality;
		g.DrawImage(codeImage, rect);
	}	
