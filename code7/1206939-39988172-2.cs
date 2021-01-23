	public static SlidePart AppendNewSlide(PresentationPart presentationPart, SlideLayoutPart masterLayoutPart, out IEnumerable<Shape> placeholderShapes)
	{
		Slide clonedSlide = new Slide() {
			ColorMapOverride = new ColorMapOverride {
				MasterColorMapping = new Draw.MasterColorMapping()
			}
		};
		SlidePart clonedSlidePart = presentationPart.AddNewPart<SlidePart>();
		clonedSlidePart.Slide = clonedSlide;
		clonedSlidePart.AddPart(masterLayoutPart);
		clonedSlide.Save(clonedSlidePart);
		var masterShapeTree = masterLayoutPart.SlideLayout.CommonSlideData.ShapeTree;
		placeholderShapes = (from s in masterShapeTree.ChildElements<Shape>()
							   where s.NonVisualShapeProperties.OfType<ApplicationNonVisualDrawingProperties>().Any(anvdp=>anvdp.PlaceholderShape != null)
							   select new Shape()
							   {
								   NonVisualShapeProperties = (NonVisualShapeProperties)s.NonVisualShapeProperties.CloneNode(true),
								   TextBody = new TextBody(s.TextBody.ChildElements<Draw.Paragraph>().Select(p => p.CloneNode(true))) {
									   BodyProperties = new Draw.BodyProperties(),
									   ListStyle = new Draw.ListStyle()
								   },
								   ShapeProperties = new ShapeProperties()
							   }).ToList();
		clonedSlide.CommonSlideData = new CommonSlideData
		{
			ShapeTree = new ShapeTree(placeholderShapes) {
				GroupShapeProperties = (GroupShapeProperties)masterShapeTree.GroupShapeProperties.CloneNode(true),
				NonVisualGroupShapeProperties = (NonVisualGroupShapeProperties)masterShapeTree.NonVisualGroupShapeProperties.CloneNode(true)
			}
		};
		SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;
		// Find the highest slide ID in the current list.
		uint maxSlideId = slideIdList.Max(c=>(uint?)((SlideId)c).Id) ?? 256;
		// Insert the new slide into the slide list after the previous slide.
		slideIdList.Append(new SlideId() {
			Id = ++maxSlideId,
			RelationshipId = presentationPart.GetIdOfPart(clonedSlidePart)
		});
		//presentationPart.Presentation.Save();
		return clonedSlidePart;
	}
    //helper method used above in separate static class
	public static IEnumerable<T> ChildElements<T>(this OpenXmlElement el) where T: OpenXmlElement
	{
		if (el.HasChildren)
		{
			var child = el.GetFirstChild<T>();
			while (child != null)
			{
				yield return child;
				child = child.NextSibling<T>();
			}
		}
	}
