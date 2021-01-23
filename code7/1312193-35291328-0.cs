    Microsoft.Office.Interop.Excel.Application excelApp = null;
    try
     {
        excelApp = (Microsoft.Office.Interop.Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
      }
    catch
        {
         }
    if (excelApp == null)
       {
        excelApp = new Microsoft.Office.Interop.Excel.Application();
        }
        ' **HERE** - Open workbooks with excelApp.Workbooks.Open(...)
         for (int i = 0; i < excelApp.Windows.Count; i++)
          {
                       //my work....... 
           }
