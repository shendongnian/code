    PdfReader reader = new PdfReader(@"D:\test pdf\Blood Journal.pdf");
    int intPageNum = reader.NumberOfPages;    
    private string GetColumnText(float llx, float lly, float urx, float ury)
    {
        var rect = new iTextSharp.text.Rectangle(llx, lly, urx, ury);
        var renderFilter = new RenderFilter[1];
        renderFilter[0] = new RegionTextRenderFilter(rect);
        var textExtractionStrategy =
                new FilteredTextRenderListener(new LocationTextExtractionStrategy(),
                                               renderFilter);
        var text = PdfTextExtractor.GetTextFromPage(reader, intPageNum,
                                                    textExtractionStrategy);
        return text;
    }
