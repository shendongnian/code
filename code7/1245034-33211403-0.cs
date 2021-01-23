    public static bool ContainsSheet(this Excel.Workbook workbook, string sheetName)
    {
         foreach (var sheet in workbook.Sheets)
         {
              if (sheet.Name.Equals(sheetName))
              {
                   return true;
              }
         }
         return false;
    }
