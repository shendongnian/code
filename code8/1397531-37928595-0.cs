    var wb = new XSSFWorkbook();
    var sheet = wb.CreateSheet("Sheet 1");
      
    // Create an italic font
    var font = wb.CreateFont();
    font.IsItalic = true;
    // Create a dedicated cell style using that font 
    var style = wb.CreateCellStyle();
    style.SetFont(font);
    style.GetFont(wb).IsItalic = true;
    var row = sheet.CreateRow(0);
    row.CreateCell(0).SetCellValue("Username");
    var cell = row.CreateCell(1);
    cell.SetCellValue("Email");
    // Apply the cellstyle we craeted
    cell.CellStyle = style;
    using (var fileData = new FileStream(@"G:\scratch\sheet2.xlsx", FileMode.Create))
    {
      wb.Write(fileData);
    }
