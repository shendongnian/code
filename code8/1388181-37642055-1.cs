    [DllImport("user32.dll")]
    static extern int GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);
    
    Process GetExcelProcess(Microsoft.Office.Interop.Excel.Application excelApp)
    {
         int id;
         GetWindowThreadProcessId(excelApp.Hwnd, out id);
         return Process.GetProcessById(id);
    }
    
    void TerminateExcelProcess(Microsoft.Office.Interop.Excel.Application excelApp)
    {
         var process = GetExcelProcess(excelApp);
         if (process != null)
         {
              process.Kill();
         }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
         // Create Instance of Excel
         Microsoft.Office.Interop.Excel.Application oXL = new Microsoft.Office.Interop.Excel.Application();
         try
         {
              // Work with oXL
         }
         finally
         {
              TerminateExcelProcess(oXL);
         }
    }
