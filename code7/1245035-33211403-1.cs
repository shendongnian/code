    public static bool ContainsSheet(this Excel.Workbook workbook, string sheetName)
    {
         if(workbook.Sheets == null || !workbook.Sheets.Any())
               return false;
         foreach (var sheet in workbook.Sheets)
         {
              if (sheet.Name.Equals(sheetName))
              {
                   return true;
              }
         }
         return false;
    }
