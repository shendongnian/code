    //The rectangle is actually changed in the cell event so it doesn't matter what we use
    TextField tf = new TextField(writer, new iTextSharp.text.Rectangle(1, 1), "cellTextBox");
    tf.Text = "test";
    tf.Font = bfHelvetica;
    tf.FontSize = 14;
    PdfPCell tbCell = new PdfPCell(new Phrase(" ", helvetica12));
    tbCell.CellEvent = new SingleCellFieldPositioningEvent(writer, tf);
