    private static void UpdateCell(SharedStringTable sharedStringTable, 
       Dictionary<string, SheetData> sheetDatas, string sheetName, 
       string cellReference, string text)
    {
       Cell cell = sheetDatas[sheetName].Descendants<Cell>()
        .FirstOrDefault(c => c.CellReference.Value == cellReference);
       if (cell == null) return;
       if (cell.DataType == null || cell.DataType != CellValues.SharedString)
       {
        cell.RemoveAllChildren();
        cell.AppendChild(new InlineString(new Text { Text = text }));
        cell.DataType = CellValues.InlineString;
        return;
       }
       // Cell is refering to string table. Check if new text is already in string table, if so use it.
       IEnumerable<SharedStringItem> sharedStringItems 
        = sharedStringTable.Elements<SharedStringItem>();
       int i = 0;
       foreach (SharedStringItem sharedStringItem in sharedStringItems)
       {
        if (sharedStringItem.InnerText == text)
        {
           cell.CellValue = new CellValue(i.ToString());
           // TODO: Should clean up, ie remove item with old text from string table if it is no longer in use.
           return;
        }
        i++;
       }
       // New text not in string table. Check if any other cells in the Workbook referes to item with old text.
       foreach (SheetData sheetData in sheetDatas.Values)
       {
        var cells = sheetData.Descendants<Cell>();
        foreach (Cell cell0 in cells)
        {
           if (cell0.DataType != null 
           && cell0.DataType == CellValues.SharedString 
           && cell0.CellValue.InnerText == cell.CellValue.InnerText)
           {
            // Other cells refer to item with old text so we cannot update it. Add new item.
            sharedStringTable.AppendChild(new SharedStringItem(new Text(text)));
            cell.CellValue.Text = (sharedStringTable.Count - 1).ToString();
            return;
           }
        }
       }
       // No other cells refered to old item. Update it.
       sharedStringItems.ElementAt(int.Parse(cell.CellValue.InnerText)).Text = new Text(text);
    }
....
    private static void DoIt(string filePath)
    {
       using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(filePath, true))
       {
        SharedStringTable sharedStringTable 
           = spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>()
            .First().SharedStringTable;
        Dictionary<string, SheetData> sheetDatas = new Dictionary<string, SheetData>();
        foreach (var sheet in spreadSheet.WorkbookPart.Workbook.Descendants<Sheet>())
        {
           SheetData sheetData 
            = (spreadSheet.WorkbookPart.GetPartById(sheet.Id) as WorksheetPart)
               .Worksheet.GetFirstChild<SheetData>();
           sheetDatas.Add(sheet.Name, sheetData);
        }
        UpdateCell(sharedStringTable, sheetDatas, "Sheet1", "A2", "Mjau");
       }
    }
    
