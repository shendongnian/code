    void Go()
    {
        Document doc = new Document(PageSize.LETTER);
        string yourPath = "foo/bar/baz.pdf";
        using (FileStream os = new FileStream(yourPath, FileMode.Create))
        {
            PdfWriter.GetInstance(doc, os); // you don't need the return value
            doc.Open();
            string fontLoc = @"c:\windows\fonts\arialuni.ttf"; // make sure to have the correct path to the font file
            BaseFont bf = BaseFont.CreateFont(fontLoc, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font f = new Font(bf, 12);
            PdfPTable table = new PdfPTable(1); // a table with 1 cell
            Phrase text = new Phrase("العقد", f);
            PdfPCell cell = new PdfPCell(text);
            table.RunDirection = PdfWriter.RUN_DIRECTION_RTL; // can also be set on the cell
            table.AddCell(cell);
            doc.Add(table);
            doc.Close();
        }
    }
