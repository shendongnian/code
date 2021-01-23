    //Create your name as you normally do
    var table = new PdfPTable(3);
    //Bind and instance with properties set
    table.TableEvent = new TopBottomTableBorderMaker(BaseColor.BLACK, 0.5f);
    
    //The rest is the same
    for (var i = 0; i < 6; i++) {
        var cell = new PdfPCell(new Phrase(i.ToString()));
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
        cell.BackgroundColor = new iTextSharp.text.BaseColor(220, 220, 220);
        cell.Border = 0;
        cell.BorderColorLeft = BaseColor.BLACK;
        cell.BorderWidthLeft = .5f;
        cell.BorderColorRight = BaseColor.BLACK;
        cell.BorderWidthRight = .5f;
        table.AddCell(cell);
    }
