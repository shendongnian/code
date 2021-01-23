    //Working folder
    var exportFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SO_17589177");
    System.IO.Directory.CreateDirectory(exportFolder);
    //File 1 is our "template" file, File 2 is our final file
    var file_1 = System.IO.Path.Combine(exportFolder, "file_1.pdf");
    var file_2 = System.IO.Path.Combine(exportFolder, "file_2.pdf");
    //Will hold a rectangle based on the last known coordinates
    iTextSharp.text.Rectangle tableRectStart;
    
    using (var fs = new FileStream(file_1, FileMode.Create, FileAccess.Write, FileShare.None)) {
        using (var doc = new Document()) {
            using (var writer = PdfWriter.GetInstance(doc, fs)) {
                doc.Open();
                for (var i = 0; i < 10; i++) {
                    doc.Add(new Paragraph("Hello world"));
                }
                //Store our coordinates for later
                tableRectStart = new iTextSharp.text.Rectangle(doc.Left, doc.Bottom, doc.Right, writer.GetVerticalPosition(false));
                doc.Close();
            }
        }
    }
    using (var r = new PdfReader(file_1)) {
        using (var fs = new FileStream(file_2, FileMode.Create, FileAccess.Write, FileShare.None)) {
            using (var stamper = new PdfStamper(r, fs)) {
                //We want to target the last page of the previous PDF
                int pageNumber = r.NumberOfPages;
                //Store the last page's size which is what we'll use for new pages later
                var docRect = r.GetPageSize(pageNumber);
                //Create a giant table
                var t = new PdfPTable(2);
                for (var i = 0; i < 1000; i++) {
                    t.AddCell(String.Format("This is cell {0}", i));
                }
                //Create our stamper bound to the last page of our source document
                var ct = new ColumnText(stamper.GetOverContent(pageNumber));
                //Add our table to the stamper
                ct.AddElement(t);
                //Set the drawing area for the table
                ct.SetSimpleColumn(tableRectStart);
                //Infinite loop below that is responsible for breaking itself out
                //Might want to add guards in case content gets too big and always overflows
                while (true) {
                    //Draw the text and pass the status back to a helper
                    //method that tells us if there's more text to be drawn
                    if (! ColumnText.HasMoreText(ct.Go())) {
                        //If there isn't any more text then exit the infinite loop
                        break;
                    }
                    //Reset our rectangle to the document's rectangle
                    tableRectStart = docRect;
                    //Increment the current page number (which we need to keep track of)
                    //and insert a new page
                    stamper.InsertPage(++pageNumber, docRect);
                    //Tell the ColumnText to draw on a new page
                    ct.Canvas = stamper.GetOverContent(pageNumber);
                    //Reset the drawing canvas area
                    //TODO: Include some margin logic here probably
                    ct.SetSimpleColumn(docRect);
                }
            }
        }
    }
