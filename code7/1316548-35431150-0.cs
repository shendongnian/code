    using System;
    using System.Drawing;
    using System.Text;
    using GemBox.Spreadsheet;
    
    class Sample
    {
        [STAThread]
        static void Main(string[] args)
        {
            // If using Professional version, put your serial key below.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
    
            ExcelFile ef = ExcelFile.Load("test.xlsx");
    
            ef.Save("Convert.pdf");
        }
    }
