    public void TrimLeftandRightFoall(string sourceFilePath, string outputFilePath, float cropwidth)
    {
        PdfReader pdfReader = new PdfReader(sourceFilePath);
        float width = (float)GetPDFwidth(sourceFilePath);
        float height = (float)GetPDFHeight(sourceFilePath);
        float widthTo_Trim = iTextSharp.text.Utilities.MillimetersToPoints(cropwidth);
        PdfRectangle rectLeftside = new PdfRectangle(widthTo_Trim, widthTo_Trim, width-widthTo_Trim , height-widthTo_Trim);
        using (var output = new FileStream(outputFilePath, FileMode.CreateNew, FileAccess.Write))
        {
            // Create a new document
            Document doc = new Document();
            // Make a copy of the document
            PdfSmartCopy smartCopy = new PdfSmartCopy(doc, output);
            // Open the newly created document
            doc.Open();
            // Loop through all pages of the source document
            for (int i = 1; i <= pdfReader.NumberOfPages; i++)
            {
                // Get a page
                var page = pdfReader.GetPageN(i);
                page.Put(PdfName.MEDIABOX, rectLeftside);
                    
                var copiedPage = smartCopy.GetImportedPage(pdfReader, i);
                smartCopy.AddPage(copiedPage);
            }
             
            doc.Close();
        }
    }
