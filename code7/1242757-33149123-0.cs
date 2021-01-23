    public static float CalculatePdfPTableHeight(PdfPTable table)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            using (Document doc = new Document(PageSize.TABLOID))
            {
                using (PdfWriter w = PdfWriter.GetInstance(doc, ms))
                {
                    doc.Open();
                    table.WriteSelectedRows(0, table.Rows.Count, 0, 0, w.DirectContent);
                    doc.Close();
                    return table.TotalHeight;
                }
            }
        }
    }
