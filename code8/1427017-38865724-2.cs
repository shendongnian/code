    /// <summary>
    /// Adds image
    /// </summary>
    /// <param name="filename">image</param>
    /// <param name="mainpart">main document part</param>
    /// <param name="contentOpenXmlElement">element where picture will be added</param>
    private static void AddImage(string filename, MainDocumentPart mainpart, OpenXmlElement contentOpenXmlElement)
    {
    	Picture pic = contentOpenXmlElement.Descendants().Where(x => x is Picture).FirstOrDefault() as Picture;
    
    	if (null != pic)
    	{
    		byte[] imageFileBytes = Convert.FromBase64String(filename);
    
    		Bitmap image = new Bitmap(new MemoryStream(imageFileBytes));
    
    		// write the image to the document
    		string SigId = "b" + Guid.NewGuid();
    		//var imagePart = mainpart.AddNewPart<ImagePart>("image/png", SigId);
    
    		//using (BinaryWriter writer = new BinaryWriter(imagePart.GetStream()))
    		//{
    		//    writer.Write(imageFileBytes);
    		//    writer.Flush();
    		//}
    
    		ImagePart imagePart = mainpart.AddNewPart<ImagePart>("image/png", SigId);
    		using (MemoryStream ms = new MemoryStream())
    		{
    			image.Save(ms, ImageFormat.Png);
    			ms.Position = 0;
    			imagePart.FeedData(ms);
    		}
    
    
    		//make sure image dimensions are respected and our image is centered in the container
    		if (image.Width / (double)image.Height > pic.ShapeProperties.Transform2D.Extents.Cx / (double)pic.ShapeProperties.Transform2D.Extents.Cy)
    		{
    			long oldcy = pic.ShapeProperties.Transform2D.Extents.Cy;
    			pic.ShapeProperties.Transform2D.Extents.Cy = (long)(pic.ShapeProperties.Transform2D.Extents.Cx * image.Height / (double)image.Width);
    			pic.ShapeProperties.Transform2D.Offset.Y = (oldcy - pic.ShapeProperties.Transform2D.Extents.Cy) >> 1;
    		}
    		else
    		{
    			long oldcx = pic.ShapeProperties.Transform2D.Extents.Cx;
    			pic.ShapeProperties.Transform2D.Extents.Cx = (long)(pic.ShapeProperties.Transform2D.Extents.Cy * image.Width / (double)image.Height);
    			pic.ShapeProperties.Transform2D.Offset.X = (oldcx - pic.ShapeProperties.Transform2D.Extents.Cx) >> 1;
    		}
    
    		pic.BlipFill = new BlipFill(new Blip { Embed = SigId }, new Stretch(new FillRectangle()));
    
    		var element = new Drawing(new Inline(
    							new Extent { Cx = pic.ShapeProperties.Transform2D.Extents.Cx, Cy = pic.ShapeProperties.Transform2D.Extents.Cy },
    							new EffectExtent { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
    							new DocProperties { Id = (UInt32Value)1U, Name = "Picture 1" },
    							new NonVisualGraphicFrameDrawingProperties(
    							new A.GraphicFrameLocks { NoChangeAspect = true }),
    									new A.Graphic(new A.GraphicData(new Picture(
    											new PIC.NonVisualPictureProperties(
    												new PIC.NonVisualDrawingProperties { Id = (UInt32Value)0U, Name = "New Bitmap Image.jpg" },
    													new PIC.NonVisualPictureDrawingProperties()),
    											new BlipFill(new Blip(new A.BlipExtensionList(
    												new A.BlipExtension { Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}" }))
    											{ Embed = SigId, CompressionState = A.BlipCompressionValues.Print },
    											new Stretch(new FillRectangle())),
    											new PIC.ShapeProperties(new A.Transform2D(
    											new A.Offset { X = pic.ShapeProperties.Transform2D.Offset.X, Y = pic.ShapeProperties.Transform2D.Offset.Y },
    											new A.Extents { Cx = pic.ShapeProperties.Transform2D.Extents.Cx, Cy = pic.ShapeProperties.Transform2D.Extents.Cy }),
    											new A.PresetGeometry(new A.AdjustValueList()) { Preset = A.ShapeTypeValues.Rectangle }))
    											) { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" }))
    											 {
    												 DistanceFromTop = (UInt32Value)0U,
    												 DistanceFromBottom = (UInt32Value)0U,
    												 DistanceFromLeft = (UInt32Value)0U,
    												 DistanceFromRight = (UInt32Value)0U,
    												 EditId = "50D07946"
    											 });
    
    		contentOpenXmlElement.RemoveAllChildren();
    		contentOpenXmlElement.AppendChild(new Paragraph(new Run(element)));
    	}
    }
