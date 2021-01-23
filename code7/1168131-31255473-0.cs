    public class UsedRangeCache 
    {
        protected static Dictionary<IntPtr, ExcelReference> _usedRanges = new Dictionary<IntPtr, ExcelReference>();
        protected static Application _app;
        /// <summary>
        /// Call this method when the XLL is initialized
        /// </summary>
        public static void Initialize(Application app)
        {
            _app = app;
            for (int i = 0; i < app.Workbooks.Count; i++ )
            {
                app_WorkbookOpen(app.Workbooks[i + 1]);
            }
            app.WorkbookOpen += app_WorkbookOpen;
            app.WorkbookBeforeClose += app_WorkbookBeforeClose;
            app.AfterCalculate += app_AfterCalculate;
        }
        // Refresh references
        static void app_AfterCalculate()
        {
            for (int i = 0; i < _app.Workbooks.Count; i++)
            {
                UpdateCache(_app.Workbooks[i + 1]);
            }
        }
        // Remove references
        static void app_WorkbookBeforeClose(Workbook book, ref bool Cancel)
        {
            for (int i = 0; i < book.Worksheets.Count; i++)
            {
                Worksheet sheet = book.Worksheets[i + 1] as Worksheet;
                if (sheet != null)
                {
                    ExcelReference xref = (ExcelReference)XlCall.Excel(XlCall.xlSheetId, sheet.Name);
                    if (_usedRanges.ContainsKey(xref.SheetId))
                    {
                        _usedRanges.Remove(xref.SheetId);
                    }
                }
            }
        }
        // Create references
        static void app_WorkbookOpen(Workbook book)
        {
            UpdateCache(book);
        }
        // Update cache
        private static void UpdateCache(Workbook book)
        {
            for (int i = 0; i < book.Worksheets.Count; i++)
            {
                Worksheet sheet = book.Worksheets[i + 1] as Worksheet;
                if (sheet != null)
                {
                    ExcelReference xref = (ExcelReference)XlCall.Excel(XlCall.xlSheetId, sheet.Name);
                    ExcelReference xused = new ExcelReference(
                        sheet.UsedRange.Row,
                        sheet.UsedRange.Row + sheet.UsedRange.Rows.Count,
                        sheet.UsedRange.Column,
                        sheet.UsedRange.Column + sheet.UsedRange.Columns.Count,
                        xref.SheetId);
                    if (_usedRanges.ContainsKey(xref.SheetId)) 
                    { 
                        _usedRanges.Remove(xref.SheetId); 
                    }
                    _usedRanges.Add(xref.SheetId, xused);
                }
            }
        }
        /// <summary>
        /// Get used range
        /// </summary>
        public static ExcelReference GetUsedRange(ExcelReference xref)
        {
            return (_usedRanges.ContainsKey(xref.SheetId) 
                ? _usedRanges[xref.SheetId] 
                : null);
        }
    }
