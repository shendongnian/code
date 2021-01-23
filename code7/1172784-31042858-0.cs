    // This is right: if you want to use ColumnText, you need a PdfContentByte
    PdfContentByte cb = writer.DirectContent;
    // This may not be necessary if you merely need Helvetica Bold in a Paragraph, but it's not incorrect.
    BaseFont title = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.WINANSI, BaseFont.EMBEDDED);
    // YOU DON'T NEED THE FOLLOWING LINE. PLEASE REMOVE IT!
    cb.SetFontAndSize(title, 10); //10 is the font size
    // OK, you're just defining a string
    string text = "this is sample of long long long paragraph..";
    // OK, you're defining a ColumnText object and defining the rectangle
    ColumnText column1 = new ColumnText(cb);
    column1.SetSimpleColumn(255, 145, 600, 100);         
    // OK, you're defining a paragraph
    Paragraph p;
    // This is strange: why do you nest paragraphs?
    // Why don't you use the font?
    p = new Paragraph(new Paragraph(text));
    // You are forgetting a line here: where do you add the paragraph to the column?
    // Nothing will happen here:
    column1.Go();
