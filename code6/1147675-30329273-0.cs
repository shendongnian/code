    Workbook workBook = new Workbook();
    
    Worksheet workSheetIntroduction = workBook.Worksheets[0];
    
    
    //This Style object will make the fill color Red and font Bold
    
    Style boldStyle = workBook.CreateStyle();
    
    boldStyle.ForegroundColor = Color.Red;
    
    boldStyle.Pattern = BackgroundType.Solid;
    
    boldStyle.Font.IsBold = true;
    
    
    //Bold style flag options
    
    StyleFlag boldStyleFlag = new StyleFlag();
    
    boldStyleFlag.HorizontalAlignment = true;
    
    boldStyleFlag.FontBold = true;
    
    
    //Apply this style to row 1
    
    Row row1 = workBook.Worksheets[0].Cells.Rows[0];
    
    row1.ApplyStyle(boldStyle, boldStyleFlag);
    
    
    
    //Now set the style of indvidual cell
    
    Cell c = workSheetIntroduction.Cells["B1"];
    
    
    Style s = c.GetStyle();
    
    s.ForegroundColor = Color.Red;
    
    s.Pattern = BackgroundType.Solid;
    
    s.Font.IsBold = true;
    
    c.SetStyle(s);
    
    
    //Save the workbook
    
    workBook.Save("output.xlsx");
