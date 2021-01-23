     public Document GetPDFparams(Document disclaimer)
        {
            StringBuilder Content = new StringBuilder();
            Content.Append("Testing");
            Paragraph NullContent = new Paragraph(Content.ToString(), FontFactory.GetFont(FontFactory.TIMES_ROMAN, font_size, Font.NORMAL));
            disclaimer.Add(NullContent);
            PdfPTable tableh = new PdfPTable(6);
            tableh.WidthPercentage = 100;
            tableh.SetTotalWidth(new float[] { 30f, 30f, 30f, 30f,30f,30f });
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Images/ORIXLOGO.png"));
            //img.ScaleToFit(100, 40);
            PdfPCell LogoCell = new PdfPCell(img);
            LogoCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            LogoCell.VerticalAlignment = Element.ALIGN_BOTTOM;
            LogoCell.Colspan = 2;
            LogoCell.Padding = 20;
            LogoCell.Border = 0;
            //LogoCell.Indent = 0;        
    
            tableh.AddCell(LogoCell);
           
    
            Phrase LogoText = new Phrase("ORIX LEASING PAKISTAN LIMITED", FontFactory.GetFont(FontFactory.TIMES_BOLD, font_size));
            PdfPCell LogoTextCell = new PdfPCell(LogoText);
            LogoTextCell.HorizontalAlignment = Element.ALIGN_LEFT;
            LogoTextCell.VerticalAlignment = Element.ALIGN_LEFT;
            LogoTextCell.Border = Rectangle.NO_BORDER;
            tableh.AddCell(LogoTextCell);
            tableh.AddCell(LogoTextCell);
            tableh.AddCell(LogoTextCell);
            tableh.AddCell(LogoTextCell);
    
            disclaimer.Add(tableh);
            return disclaimer;
        }
