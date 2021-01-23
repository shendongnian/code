    public static class Extensions
    {
        public static void SetActiveSheet(this XLWorkbook workbook, IXLWorksheet sheetToSetActive)
        {
            foreach (var sheet in workbook.Worksheets)
            {
                var isCurrentSheet = sheet.Equals(sheetToSetActive);
                sheet.SetTabActive(isCurrentSheet);
                sheet.SetTabSelected(isCurrentSheet);
            }
        }
    }
