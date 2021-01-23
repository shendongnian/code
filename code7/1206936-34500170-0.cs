    public static void InsertNewSlideB(PresentationDocument presentationDocument, int position, string slideTitle)
    {
        if (presentationDocument == null)
        {
            throw new ArgumentNullException("presentationDocument");
        }
        if (slideTitle == null)
        {
           throw new ArgumentNullException("slideTitle");
        }
        PresentationPart presentationPart = presentationDocument.PresentationPart;
        // Verify that the presentation is not empty.
        if (presentationPart == null)
        {
            throw new InvalidOperationException("The presentation document is empty.");
        }
        // Declare and instantiate a new slide.
        Slide slide = new Slide(new CommonSlideData(new ShapeTree()));
        SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();
        slide.Save(slidePart);
        SlideLayoutPart layoutPart = presentationPart.SlideMasterParts.ElementAt(0).SlideLayoutParts.ElementAt(1);
        slidePart.AddPart<SlideLayoutPart>(layoutPart);
        slidePart.Slide.CommonSlideData = (CommonSlideData)layoutPart.SlideLayout.CommonSlideData.Clone();
        SetTitle(slidePart, slideTitle);
        SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;
        // Find the highest slide ID in the current list.
        uint maxSlideId = 1;
        SlideId prevSlideId = null;
        foreach (SlideId slideId in slideIdList.ChildElements)
         {
            if (slideId.Id > maxSlideId)
            {
                maxSlideId = slideId.Id;
            }
            position--;
            if (position == 0)
            {
                prevSlideId = slideId;
            }
        }
        maxSlideId++;
        // Insert the new slide into the slide list after the previous slide.
        SlideId newSlideId = slideIdList.InsertAfter(new SlideId(), prevSlideId);
        newSlideId.Id = maxSlideId;
        newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);
        // Save the modified presentation.
        presentationPart.Presentation.Save();
    }
