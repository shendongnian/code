    public void ProcessFile(HttpPostedFile pptxFile)
    {
        int slideCount = 0;
 
        using (var document = PresentationDocument.Open(pptxFile.InputStream, false))
        {
            PresentationPart presentationPart = doc.PresentationPart;
            slideCount = presentationPart.SlideParts.Count();
        }
    }
