    using (var copyms = new MemoryStream())
    {
        var document = new Document();
        using (PdfSmartCopy copy = new PdfSmartCopy(document, copyms))
        {
            document.Open();
            foreach (var item in Items)
            {
                // Read the template
                var pdfReader = new PdfReader(TemplateLocation);
                // Save the current completed template to a MemoryStream
                using (var ms = new MemoryStream())
                {
                    using (PdfStamper stamper = new PdfStamper(pdfReader, ms))
                    {
                        var fields = stamper.AcroFields;
                        // Set the field values here
                        stamper.FormFlattening = true;
                    }
                    pdfReader = new PdfReader(ms.ToArray());
                    // Copy the memorystream to the main document
                    copy.AddDocument(pdfReader);
                }
            }
        }
        document.CloseDocument();
        // Combine on A3 pages in new document
        var a3doc = new Document(PageSize.A3.Rotate(), 0, 0, 0, 0);
        var a3reader = new PdfReader(copyms.ToArray());
        var a3writer = PdfWriter.GetInstance(a3doc, new FileStream(outputFileLocation, FileMode.Create));
        a3doc.Open();
        var a3cb = a3writer.DirectContent;
        PdfImportedPage page;
        int totalPages = a3reader.NumberOfPages;
        for (int i = 1; i <= (int)Math.Ceiling(totalPages / 2); i++)
        {
            // Create an A3 page
            a3doc.NewPage();
            var a3size = PageSize.A3.Rotate();
            page = a3writer.GetImportedPage(a3reader, (i * 2) + 1);
            a3cb.AddTemplate(page, 0, 0);
            page = a3writer.GetImportedPage(a3reader, (i * 2) + 2);
            a3cb.AddTemplate(page, (int)(a3size.Width / 2), 0);                    
        }
        a3doc.CloseDocument();
    }
