    public String ExtractAnnotationText(PdfStream xObject)
    {
        PdfDictionary resources = xObject.GetAsDict(PdfName.RESOURCES);
        ITextExtractionStrategy strategy = new LocationTextExtractionStrategy();
        PdfContentStreamProcessor processor = new PdfContentStreamProcessor(strategy);
        processor.ProcessContent(ContentByteUtils.GetContentBytesFromContentObject(xObject), resources);
        return strategy.GetResultantText();
    }
