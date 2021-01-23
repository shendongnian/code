		public void createPDF()
		{
			try {
				org.pdfclown.files.File file = new org.pdfclown.files.File();
				org.pdfclown.documents.Document document = file.Document;
				org.pdfclown.documents.Page page = new org.pdfclown.documents.Page(document);
				document.Pages.Add(page);
				org.pdfclown.documents.contents.composition.PrimitiveComposer composer = new org.pdfclown.documents.contents.composition.PrimitiveComposer(page);
				composer.SetFont(new org.pdfclown.documents.contents.fonts.StandardType1Font(document, org.pdfclown.documents.contents.fonts.StandardType1Font.FamilyEnum.Courier, true, false), 32);
				composer.ShowText("Hello World!", new System.Drawing.PointF(32, 48));				
				org.pdfclown.documents.contents.entities.Image image = LoadImageFile("test.jpg");
				org.pdfclown.documents.contents.xObjects.XObject imageXObject = image.ToXObject(document);
				composer.ShowXObject(imageXObject, new System.Drawing.PointF(32, 80));				
				composer.Flush();
				file.Save("test.pdf", org.pdfclown.files.SerializationModeEnum.Incremental);
				System.Diagnostics.Process.Start("explorer", System.IO.Directory.GetParent(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName).ToString());
			} catch (System.Exception e) {
				System.Windows.Forms.MessageBox.Show(e.Message + "\r\n" + e.StackTrace);
			}
		}
    	
		public org.pdfclown.documents.contents.entities.Image LoadImageFile(string path)
		{
			System.Drawing.Image image = System.Drawing.Image.FromFile(path);
			var ep = new System.Drawing.Imaging.EncoderParameters(3);
			ep.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
			ep.Param[1] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.ScanMethod, (int)System.Drawing.Imaging.EncoderValue.ScanMethodInterlaced);
			ep.Param[2] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.RenderMethod, (int)System.Drawing.Imaging.EncoderValue.RenderNonProgressive);
			System.IO.MemoryStream memStream = new System.IO.MemoryStream();
    			
			System.Drawing.Imaging.ImageCodecInfo encoder_info = null;
			int j;
			System.Drawing.Imaging.ImageCodecInfo[] encoders;
			encoders = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders();
			for (j = 0; j < encoders.Length; ++j) {
				if (encoders[j].MimeType.Equals("image/jpeg"))
					encoder_info = encoders[j];
			}
    			
			image.Save(memStream, encoder_info, ep);
			memStream.Position = 0;
			return org.pdfclown.documents.contents.entities.Image.Get(memStream);
		}
