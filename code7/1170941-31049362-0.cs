		private static void ReplaceBookmarksWithImage(string wordDocTempaltePath, string imageFilename)
		{
			WordprocessingDocument doc = WordprocessingDocument.Open(wordDocTempaltePath, true);
			// Read all bookmarks from the word doc
			foreach (BookmarkStart bookmarkStart in doc.MainDocumentPart.RootElement.Descendants<BookmarkStart>())
			{
				// insert the image
				InsertImageIntoBookmark(doc, bookmarkStart, imageFilename);
				// remove the bookmark
				bookmarkStart.Remove();
			}
			doc.Close();
		}
		public static void InsertImageIntoBookmark(WordprocessingDocument doc, BookmarkStart bookmarkStart, string imageFilename)
		{
			// Remove anything present inside the bookmark
			OpenXmlElement elem = bookmarkStart.NextSibling();
			while (elem != null && !(elem is BookmarkEnd))
			{
				OpenXmlElement nextElem = elem.NextSibling();
				elem.Remove();
				elem = nextElem;
			}
			// Create an imagepart
			var imagePart = AddImagePart(doc.MainDocumentPart, imageFilename);
			// insert the image part after the bookmark start
			AddImageToBody(doc.MainDocumentPart.GetIdOfPart(imagePart), bookmarkStart);
		}
		public static ImagePart AddImagePart(MainDocumentPart mainPart, string imageFilename)
		{
			ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
			using (FileStream stream = new FileStream(imageFilename, FileMode.Open))
			{
				imagePart.FeedData(stream);
			}
			return imagePart;
		}
		private static void AddImageToBody(string relationshipId, BookmarkStart bookmarkStart)
		{
			// Define the reference of the image.
			var element =
				new Drawing(
					new DW.Inline(
						new DW.Extent()
							{
								Cx = 990000L,
								Cy = 792000L
							},
						new DW.EffectExtent() { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
						new DW.DocProperties() { Id = (UInt32Value)1U, Name = "Picture 1" },
						new DW.NonVisualGraphicFrameDrawingProperties(new A.GraphicFrameLocks() { NoChangeAspect = true }),
						new A.Graphic(
							new A.GraphicData(
								new PIC.Picture(
									new PIC.NonVisualPictureProperties(
										new PIC.NonVisualDrawingProperties()
											{
												Id = (UInt32Value)0U,
												Name = "New Bitmap Image.jpg"
											},
										new PIC.NonVisualPictureDrawingProperties()),
									new PIC.BlipFill(
										new A.Blip(
											new A.BlipExtensionList(
												new A.BlipExtension()
													{
														Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}"
													}))
											{
												Embed
													=
													relationshipId,
												CompressionState
													=
													A
													.BlipCompressionValues
													.Print
											},
										new A.Stretch(new A.FillRectangle())),
									new PIC.ShapeProperties(
										new A.Transform2D(new A.Offset() { X = 0L, Y = 0L }, new A.Extents() { Cx = 990000L, Cy = 792000L }),
										new A.PresetGeometry(new A.AdjustValueList()) { Preset = A.ShapeTypeValues.Rectangle })))
								{
									Uri =
										"http://schemas.openxmlformats.org/drawingml/2006/picture"
								}))
						{
							DistanceFromTop = (UInt32Value)0U,
							DistanceFromBottom = (UInt32Value)0U,
							DistanceFromLeft = (UInt32Value)0U,
							DistanceFromRight = (UInt32Value)0U,
							EditId = "50D07946"
						});
			// add the image element to body, the element should be in a Run.
			bookmarkStart.Parent.InsertAfter<Run>(new Run(element), bookmarkStart);
		}
