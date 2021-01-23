    int pageCount = reader.NumberOfPages;
    for (int pageno = 1; pageno <= pageCount; pageno++)
    {
        myLocationTextExtractionStrategy strategy = new myLocationTextExtractionStrategy();
        strategy.UndercontentHorizontalScaling = 100;
        string currentText = PdfTextExtractor.GetTextFromPage(reader, pageno, strategy);
