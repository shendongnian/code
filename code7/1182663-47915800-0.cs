    Novacode.Table t = doc.InsertTable(2, 3); // 2 rows; 3 columns
    t.Rows[0].Cells[0].Paragraphs[0].Append("A1").KeepWithNext(true);
    t.Rows[0].Cells[1].Paragraphs[0].Append("B1");
    t.Rows[0].Cells[2].Paragraphs[0].Append("C1");
    t.Rows[0].Cells[0].Paragraphs[0].KeepWithNext(true);
    t.Rows[1].Cells[0].Paragraphs[0].Append("A2").KeepWithNext(true);
    t.Rows[1].Cells[1].Paragraphs[0].Append("B2");
    t.Rows[1].Cells[2].Paragraphs[0].Append("C2");
