    using (PresentationDocument presentationDocument = PresentationDocument.Open(filepath, false))
    {
        PresentationPart presentationPart = presentationDocument.PresentationPart;
        if (presentationPart != null && presentationPart.Presentation != null)
        {
            Presentation presentation = presentationPart.Presentation;
            if (presentation.SlideIdList != null)
            {
                foreach (var slideId in presentation.SlideIdList.Elements<SlideId>())
                {
                    SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;
                    var shapes = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Presentation.Shape>().Where(IsTitleShape);
                    int newLines = shapes.SelectMany(s => s.Descendants<DocumentFormat.OpenXml.Drawing.Break>()).Count();
                    Console.WriteLine("Slide {0} has {1} new lines", slidePart.Uri, newLines);
                }
            }
        }
    }
