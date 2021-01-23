    //Number of labels across
    var labelsAcross = 2;
    //Total number of labels that you need.
    //This variable could come from a .Count() or you could
    //remove it and customize the for loop below
    var labelCount = 7;
    //We're going to dump our PDF into this when done
    Byte[] bytes;
    //Standard iTextSharp setup here, nothing special
    using (var ms = new MemoryStream()) {
        //Change the margins if you want to
        using (var doc = new Document()) {
            using (var writer = PdfWriter.GetInstance(doc, ms)) {
                doc.Open();
                //Create a master outer table to hold everything
                var masterTable = new PdfPTable(labelsAcross);
                //We don't want borders on the master table
                //The DefaultCell is also where you can adjust
                //padding between labels themselves
                masterTable.DefaultCell.BorderWidth = 0;
                //Create a bunch of labels
                for (var i = 1; i <= labelCount; i++) {
                    var t = new PdfPTable(2);
                    t.AddCell("This is my left cell");
                    t.AddCell("This is my right cell");
                    
                    masterTable.AddCell(t);
                }
                //Just in case we don't have enough cells
                //tell the master table to "fill in the blanks"
                masterTable.CompleteRow();
                //Add the master table to the document
                doc.Add(masterTable);
                doc.Close();
            }
        }
        //Right before closing out our stream grab the underlying byte array
        bytes = ms.ToArray();
    }
    //For demo purposes, write the bytes to the desktop
    System.IO.File.WriteAllBytes(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.pdf"), bytes);
