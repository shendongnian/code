	var bitmap = new Bitmap(512, 256);
	var graphics = Graphics.FromImage(bitmap);
	graphics.Clear(System.Drawing.Color.White);
	var font = new Font("Segoe UI", 16);
	graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
	graphics.DrawString("Hello World", font, System.Drawing.Brushes.Black, 0, 0);
	ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/tiff");
	var myEncoderParameters = new EncoderParameters(1);
	myEncoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionCCITT4);
	bitmap.Save(@"myimage.tif", myImageCodecInfo, myEncoderParameters);
	graphics.Dispose();
		private static ImageCodecInfo GetEncoderInfo(String mimeType)
		{
			int j;
			ImageCodecInfo[] encoders;
			encoders = ImageCodecInfo.GetImageEncoders();
			for (j = 0; j < encoders.Length; ++j)
			{
				if (encoders[j].MimeType == mimeType)
					return encoders[j];
			}
			return null;
		}
