    PdfReader reader = new PdfReader(GetMasterDocument(38));
    Rectangle pageSize = reader.GetPageSize(1);
    using (FileStream stream = new FileStream(
        outputFile,
        FileMode.Create,
        FileAccess.Write))
    {
        using (Document document = new Document(pageSize, 0, 0, 0, 0))
        {
            PdfWriter writer = PdfWriter.GetInstance(document, stream);
            document.Open();
            PdfPTable table = new PdfPTable(2);
            table.TotalWidth = pageSize.Width;
            table.LockedWidth = true;
            table.DefaultCell.Border = Rectangle.NO_BORDER;
            table.DefaultCell.FixedHeight = pageSize.Height / 2;
 
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                PdfImportedPage page = writer.GetImportedPage(reader, i);
                table.AddCell(Image.GetInstance(page));
            }
            document.Add(table);
        }
    }
