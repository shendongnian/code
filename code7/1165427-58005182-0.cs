			PdfDocument pdf = PdfGenerator.GeneratePdf("<b>some html here</b>", PageSize.A4);
			QRCodeGenerator qrGenerator = new QRCodeGenerator();
			QRCodeData qrCodeData = qrGenerator.CreateQrCode("some text here", QRCodeGenerator.ECCLevel.Q);
			QRCode qrCode = new QRCode(qrCodeData);
			Bitmap qrCodeImage = qrCode.GetGraphic(10);
			PdfPage page = pdf.Pages[0]; //I will add it to 1st page
			// Get an XGraphics object for drawing
			XGraphics gfx = XGraphics.FromPdfPage(page);
			XImage image = XImage.FromGdiPlusImage(qrCodeImage); //you can use XImage.FromGdiPlusImage to get the bitmap object as image (not a stream)
			gfx.DrawImage(image, 50, 50, 150, 150);
    //save your pdf, dispose other objects
