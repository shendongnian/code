    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
    Font times = new Font(bfTimes, 12, Font.ITALIC, Color.BLACK);
    
    Document doc = new Document();
    PdfWriter.GetInstance(doc, new FileStream("c:\\Font.pdf", FileMode.Create));
    doc.Open();
    doc.Add(new Paragraph("This is a test using Times Roman", times));
    doc.Close();
