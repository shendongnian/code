    private void CreatePdf(Stream output) {
        var document = new Document();
        try {
            var dataTable = GetDataTable(parameters); //this line create and fill a DataTable with some values
            //get a pdf writer instance
            PdfWriter writer = PdfWriter.GetInstance(document, output);
            //open the document
            document.Open();
            //Create table
            var pdfTable = DocumentManager.CreateTable(dataTable.Columns.Count, new[] { 30f, 130f, 130f, 80f, 60f, 80f, 60f, 80f, 60f, 60f, 80f, 80f, 60f });
            //Create a simple heading
            var heading = new StringBuilder();
            heading.AppendLine("Summary");
            var contentFont = DocumentManager.GetFont(5);
            var genHeadingFont = DocumentManager.GetFont(6, true);
            var image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("/images/some.png"));
            image.WidthPercentage = 25;
            image.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
            document.Add(image);
            document.Add(new Paragraph(heading.ToString(), contentFont));
            //Create column heading
            DocumentManager.CreateColums(pdfTable, dataTable, genHeadingFont);
            //Create cells and fill with values
            DocumentManager.CreateCellAndFillValue(pdfTable, dataTable.Select(), contentFont, new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
            document.Add(pdfTable);
            
            // make sure any data in the buffer is written to the output stream
            writer.Flush();
        } finally {
            document.Close();
        }
    }
