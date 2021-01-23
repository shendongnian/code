    using System;
    using Microsoft.Office.Interop.Excel;
    namespace TestCsCom
    {
        class Program
        {
            static void Main(string[] args)
            {
	            // NOTE: Don't call Excel objects in here... 
	            //       Debugger would keep alive until end, preventing GC cleanup
	            // Call a separate function that talks to Excel
	            DoTheWork();
	            // Now Let the GC clean up (twice, to clean up cycles too)
	            GC.Collect();
	            GC.WaitForPendingFinalizers();
	            GC.Collect();
	            GC.WaitForPendingFinalizers();
            }
            static void DoTheWork()
            {
	            Application app = new Application();
	            Workbook book = app.Workbooks.Add();
	            Worksheet worksheet = book.Worksheets["Sheet1"];
                app.Visible = true;
	            for (int i = 1; i <= 10; i++) {
		            worksheet.Cells.Range["A" + i].Value = "Hello";
	            }
	            book.Save();
	            book.Close();
	            app.Quit();
	            // NOTE: No calls the Marshal.ReleaseComObject() are ever needed
            }
        }
    }
