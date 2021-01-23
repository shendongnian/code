    public void AddPage(string htmlPage)
    {
        PdfDocument doc = converter.ConvertHtmlString(htmlPage);
        pdfDocument.Append(doc);
        converter.Footer.TotalPagesOffset += doc.Pages.Count;
        converter.Footer.FirstPageNumber += doc.Pages.Count;
    }
