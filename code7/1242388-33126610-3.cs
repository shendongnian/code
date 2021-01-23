    //Create a one column table
    var outerTable = new PdfPTable(1);
    //Create a single cell for that outer table
    var outerCell = new PdfPCell();
    //Turn the border off for that cell because we're manually going to draw one
    outerCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
    //Bind our custom class for drawing the borders
    outerCell.CellEvent = new RoundRectangle();
    //Do whatever we want with the inner table
    var innerTable = new PdfPTable(3);
    for (var i = 0; i < 9; i++) {
        innerTable.AddCell("Hello");
    }
    //When done, add the inner table to the outer cell
    outerCell.AddElement(innerTable);
    //Add the outer cell to the outer table
    outerTable.AddCell(outerCell);
    //Add the outer table to the document
    doc.Add(outerTable);
