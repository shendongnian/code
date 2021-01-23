    public class ExcelInstances
    {
        HashSet<int> _ExcelProcessIDs;
        List<int> _ExcelTopLevelWindowHwnds;
        List<Excel.Application> _XLInstances;
 
        public Excel.Application[] GetExcelInstances()
        {
            _XLInstances = new List<Excel.Application>();
            _ExcelProcessIDs = new HashSet<int>();
            _ExcelTopLevelWindowHwnds = new List<int>();
           
            foreach (Process p in Process.GetProcessesByName("EXCEL")) _ExcelProcessIDs.Add(p.Id); //find all process ids related to Excel
 
            int hwnd = 0;
            var cb = new WinAPI.WindowEnumProc(GetAllExcelTopLevelWindowHwnds);
            WinAPI.EnumWindows(cb, ref hwnd);
 
            foreach (var hwnd2 in _ExcelTopLevelWindowHwnds)
            {
                var excelHwnd = 0;
                var cb2 = new WinAPI.WindowEnumProc(GetExcelWorkbooksFromExcelWindowHandles);
                WinAPI.EnumChildWindows(hwnd2, cb2, ref excelHwnd);
            }
 
            return _XLInstances.ToArray();
        }
 
        private bool GetAllExcelTopLevelWindowHwnds(int hwnd, ref int lParam)
        {
            int id = 0;
            WinAPI.GetWindowThreadProcessId(hwnd, ref id);
 
            if (_ExcelProcessIDs.Contains(id))
            {
                if (hwnd > 0)
                {
                    _ExcelTopLevelWindowHwnds.Add(hwnd);
                }
            }
 
            return true;
        }
 
        private bool GetExcelWorkbooksFromExcelWindowHandles(int hwndChild, ref int lParam)
        {
            int id = 0;
            WinAPI.GetWindowThreadProcessId(hwndChild, ref id);
 
            StringBuilder buf = new StringBuilder(128);
            WinAPI.GetClassName(hwndChild, buf, 128);
            string clsName = buf.ToString();
 
            if (clsName == "EXCEL7")
            {
                lParam = hwndChild;
                var wb = UsefulStaticMethods.GetActiveWorkbookFromExcelHandle(hwndChild);
                if (wb != null) _XLInstances.Add(wb.Parent);
            }
 
            return true;
        }
    }
