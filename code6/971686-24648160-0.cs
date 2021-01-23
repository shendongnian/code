    if(k==0)
    {
      pdfTable.AddCell(new Phrase(dataGridView1[k, i].Value.ToString().Substring(0, 12), fontTable));
    }else
    {
      pdfTable.AddCell(new Phrase(dataGridView1[k, i].Value.ToString(), fontTable));
    }
