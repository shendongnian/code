    public PdfDocument toPdf()
    {
        // Create new PDF document
        PdfDocument document = new PdfDocument();
        PdfPage page;
        foreach (var p in pages)
        {
            // Create new page
            page = document.AddPage();
            page.Width = XUnit.FromMillimeter(width);
            page.Height = XUnit.FromMillimeter(height);
            using (var gfx = XGraphics.FromPdfPage(page, XGraphicsUnit.Millimeter))
            {
                p.drawItems(gfx);
            }
        }
        return document;
    }
