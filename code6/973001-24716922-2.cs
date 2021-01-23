    iTextSharp.text.Font fontTable = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
    PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
    table.SpacingBefore = 45f;
    table.TotalWidth = 300;
    table.DefaultCell.Phrase = new Phrase() { Font = fontTable };
    for (int j = 0; j < dataGridView1.Columns.Count; j++)
    {
        if(dataGridView1.Columns[j].Name == "Something")
        {
            continue;
        }
        table.AddCell(new Phrase(dataGridView1.Columns[j].HeaderText, fontTable));
    }
    table.HeaderRows = 1;
    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        for (int k = 0; k < dataGridView1.Columns.Count; k++)
        {
            if(dataGridView1.Columns[k].Name == "Something")
            {
                continue;
            }
            if (dataGridView1[k, i].Value != null)
            {
                table.AddCell(new Phrase(dataGridView1[k, i].Value.ToString(),fontTable));
            }
        }
    }
    doc.Add(table);
