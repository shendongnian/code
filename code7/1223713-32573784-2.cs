    using System;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    namespace WinFormsComCleanup
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                DoMyExcelStuff();
                GarbageCleanup();
            }
            private void DoMyExcelStuff()
            {
                Excel.Application excelApplication = new Excel.Application();
                Excel.Workbooks books = excelApplication.Workbooks;
                Excel.Workbook wBook = books.Add("");
                Excel.Worksheet wSheet = (Excel.Worksheet)wBook.ActiveSheet;
                Excel.Styles styles = wBook.Styles;
                Excel.Style columnHeader = styles.Add("ColumnHeader");
                columnHeader.Font.Size = 12;
                columnHeader.Font.Bold = true;
                excelApplication.Range["A1"].Value = "Name";
                excelApplication.Range["A1"].Style = columnHeader;
                wBook.SaveAs(@"c:\Temp\tst" + DateTime.Now.ToString("mmss") +".xlsx");
                // No need for Marshal.ReleaseComObject(...)
                // No need for ... = null
                excelApplication.Quit();
            }
            private void GarbageCleanup()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
