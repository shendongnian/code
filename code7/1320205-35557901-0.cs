    public void CreatePdfWithDynamicTable()
    {
        using (FileStream output = new FileStream(@"test-results\content\dynamicTable.pdf", FileMode.Create, FileAccess.Write))
        using (Document document = new Document(PageSize.A4))
        {
            PdfWriter writer = PdfWriter.GetInstance(document, output);
            document.Open();
            PdfPTable table = null;
            List<PdfPCell> cells = new List<PdfPCell>();
            List<float> widths = new List<float>();
            for (int row = 1; row < 10; row++)
            {
                // retrieve the cells of the next row and put them into the list "cells"
                ...
                // if this is the first row, determine the widths of these cells and put them into the list "widths"
                ...
                // Now create the table (if it is not yet created)
                if (table == null)
                {
                    table = new PdfPTable(widths.Count);
                    table.SetWidths(widths.ToArray());
                }
                // Fill the table row
                foreach (PdfPCell cell in cells)
                    table.AddCell(cell);
                cells.Clear();
            }
            document.Add(table);
        }
    }
