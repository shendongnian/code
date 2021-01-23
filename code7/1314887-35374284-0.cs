    using System;
    using System.Windows.Forms;
    using System.IO;
    
    namespace UsedRowsCols
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private string fileName = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "Demo.xlsx");
            private string sheetName = "Sheet1";
            /// <summary>
            /// Get last row and last column for a worksheet.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void button1_Click(object sender, EventArgs e)
            {
                ExcelUsed eu = new ExcelUsed();
                ExcelLast results = eu.UsedRowsColumns(fileName, sheetName);
                // send results to Visual Studio Output window
                Console.WriteLine($"{results.Row} {results.Column}");
            }
    
            /// <summary>
            /// Get last used column for a specific row
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void button2_Click(object sender, EventArgs e)
            {
                ExcelUsed eu = new ExcelUsed();
                try
                {
                    int results = eu.LastColumnForRow(fileName, sheetName,2);
                    // send results to Visual Studio Output window
                    Console.WriteLine(results);
                }
                finally
                {
                    eu.CallGarbageCollector();
                }
            }
        }
    }
