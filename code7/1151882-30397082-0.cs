    public static void CreateWordDoc(string filename)
    {
        using (var wordDocument = WordprocessingDocument.Create(filename, WordprocessingDocumentType.Document))
        {
            // Add a main document part. 
            MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
            // Create the document structure
            mainPart.Document = new Document();
            Body body = mainPart.Document.AppendChild(new Body());
            //add a table, row and column
            Table table = body.AppendChild(new Table());
            TableRow row = table.AppendChild(new TableRow());
            TableCell tc = row.AppendChild(new TableCell());
            //create the cell properties
            TableCellProperties tcp = new TableCellProperties();
            //create the vertial alignment properties
            TableCellVerticalAlignment tcVA = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            //create the cell width
            TableCellWidth tcW = new TableCellWidth() { Type = TableWidthUnitValues.Pct, Width = "100" };
            //append the vertical alignment and cell width objects to the TableCellProperties
            tcp.Append(tcW);
            tcp.Append(tcVA);
            //append ONE TableCellProperties object to the cell
            tc.Append(tcp);
            //add some text to the cell to test.
            Paragraph para = tc.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            run.AppendChild(new Text("Hello World!"));
            mainPart.Document.Save();
        }
    }
