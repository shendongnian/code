    using (PresentationDocument doc =
                PresentationDocument.Open(filename, false))
    {
        //get the first slide
        SlidePart part = doc.PresentationPart.SlideParts.First();
        //get all ImageParts in the first slide
        List<ImagePart> imageParts = new List<ImagePart>();
        part.GetPartsOfType<ImagePart>(imageParts);
                                
        foreach (ImagePart imagePart in imageParts)
        {
            //find the picture related to the image
            Picture pic = part.Slide.Descendants<Picture>().Where(p => 
                            p.BlipFill.Blip.Embed == part.GetIdOfPart(imagePart)).FirstOrDefault();
            //Output the Title property
            Console.WriteLine(pic.NonVisualPictureProperties.NonVisualDrawingProperties.Title);
        }
    }
