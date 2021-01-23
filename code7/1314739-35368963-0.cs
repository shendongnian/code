            Process xlP = Process.Start("excel.exe");
            int id = xlP.Id;
            int hwnd = (int)Process.GetCurrentProcess().MainWindowHandle;
            Excel.Application oExcelApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            if(xlP.MainWindowTitle.Contains( oExcelApp.ActiveWorkbook.Name)   )
            {
                //Proceed further
            }
