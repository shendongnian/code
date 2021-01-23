     ICellStyle CellCentertTopAlignment = workbook.CreateCellStyle();
     CellCentertTopAlignment = workbook.CreateCellStyle();
     CellCentertTopAlignment.SetFont(fontArial16);
     CellCentertTopAlignment.Alignment = HorizontalAlignment.Center;
     CellCentertTopAlignment.VerticalAlignment = VerticalAlignment.Top;
     
     ICell Row1 = Row1.CreateCell(1); Row1.SetCellValue(new
     HSSFRichTextString("I find a solution for this Problem.."));
     Row1.CellStyle = CellCentertTopAlignment; 
     Row1.CellStyle.WrapText = true;
