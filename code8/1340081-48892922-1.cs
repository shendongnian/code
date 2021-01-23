    public void addHtmlToPdf(Document document, PdfWriter writer, String html) {
        PdfPTable table = new PdfPTable(1);
        PdfPCell cell = new PdfPCell();
        ElementList list = XMLWorkerHelper.ParseToElementList(html, null);
        foreach(IElement element in list) {
            cell.AddElement(element);
        }
        table.AddCell(cell);
        document.Add(table);
    }
