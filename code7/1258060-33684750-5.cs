    sheet.Cells[1, 1].Font.Bold = true;
    sheet.Cells[1, 1].Interior.Color = 
        System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);
    sheet.Cells[2, 1].Font.Bold = true;
    sheet.Cells[2, 1].Interior.Color = 
        System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);
    sheet.Range[sheet.Cells[4, 1], 
                sheet.Cells[4, dataGridView1.ColumnCount]].Font.Bold = true;
    sheet.Range[sheet.Cells[4, 1], 
                sheet.Cells[4, dataGridView1.ColumnCount]].Interior.Color = 
        System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Silver);
