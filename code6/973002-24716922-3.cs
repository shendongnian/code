    if (dataGridView1[k, i].Value != null)
    {
        table.AddCell(new Phrase(dataGridView1[k, i].Value.ToString(),fontTable));
    }
    else
    {
        table.AddCell(new Phrase(""));
    }
