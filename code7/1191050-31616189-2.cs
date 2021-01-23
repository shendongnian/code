    PdfPTable tbl = new PdfPTable(2);
    tbl.WidthPercentage = 100;
    tbl.HorizontalAlignment = Element.ALIGN_LEFT;
    var par = new Paragraph();
    par.SetLeading(0, 1.2f);
    par.Add(boldpart);
    par.Add(ini);
    par.Add(anchor);
    par.Add(middlePart);
    par.Add(anchorCCO);
    PdfPCell chunky = new PdfPCell();
    chunky.AddElement(par);
    chunky.BorderWidth = PdfPCell.NO_BORDER;
    tbl.AddCell(chunky);
    
    string imagepath = @"C:\Users\Default\";
    if (System.IO.File.Exists(imagepath + "OfficeUseOnlyImg.png"))
    {
        iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(imagepath + "OfficeUseOnlyImg.png");
        PdfPCell imgCell = new PdfPCell();
        imgCell.AddElement(png);
        imgCell.BorderWidth = PdfPCell.NO_BORDER;
        tbl.AddCell(imgCell);
        doc.Add(tbl);
    }
