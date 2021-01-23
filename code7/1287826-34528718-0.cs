        Document Doc = new Document(PageSize.LETTER);
    //Create our file stream
    using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.pdf"), FileMode.Create, FileAccess.Write, FileShare.Read))
    {
        //Bind PDF writer to document and stream
        PdfWriter writer = PdfWriter.GetInstance(Doc, fs);
        //Open document for writing
        Doc.Open();
        //Add a page
        Doc.NewPage();
        //Full path to the Unicode Arial file
        string ARIALUNI_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arabtype.TTF");
        //Create a base font object making sure to specify IDENTITY-H
        BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        Font f = new Font(bf, 12);
        //Write some text, the last character is 0x0278 - LATIN SMALL LETTER PHI
        Doc.Add(new Phrase("This is a ميسو ɸ", f));
        //add Arabic text, for instance in a table
        PdfPCell cell = new PdfPCell();
        cell.AddElement(new Phrase("Hello\u0682", f));
        cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
        //Close the PDF
        Doc.Close();
    }
