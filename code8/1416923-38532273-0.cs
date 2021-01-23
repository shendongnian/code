	QRCodeWriter writer = new QRCodeWriter(); 
    ZXing.Common.BitMatrix matrix;
	int size = 120; matrix = writer.encode("http://aumansoftware.com;", BarcodeFormat.QR_CODE, size, size, null);
	SizeF qrcCodeSize = new SizeF(size,size);
	UIGraphics.BeginImageContext(qrcCodeSize);
	using (CGContext cont = UIGraphics.GetCurrentContext()) { cont.SetLineWidth(1); cont.SetFillColor(UIColor.White.CGColor); cont.AddRect(new RectangleF(0,0,qrcCodeSize.Width,qrcCodeSize.Height)); cont.DrawPath(CGPathDrawingMode.Fill);
						cont.SetFillColor(UIColor.Black.CGColor);
						for (int y = 0; y < matrix.Height; y++)
						{
							for (int x = 0; x < matrix.Width; x++)
							{
								if(matrix[x,y]) cont.AddRect(new RectangleF(x,y,1,1));
							}
						}
						cont.DrawPath(CGPathDrawingMode.Fill);
						UIImage qrcImage = UIGraphics.GetImageFromCurrentImageContext();
	// show image in imageview UIImageView qrcImageView defined earlier... qrcImageView.Image = qrcImage; qrcImageView.SetNeedsDisplay();
	}//end using cont
	UIGraphics.EndImageContext();			
