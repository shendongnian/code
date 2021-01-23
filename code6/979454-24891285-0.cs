    using System;
    using System.Collections.Generic;
    using System.Text;
    using Bytescout.Spreadsheet;
    namespace Worksheets
    {
    internal class Program
    {
        private static void Main(string[] args)
        {
        // Create new Spreadsheet
            Spreadsheet document = new Spreadsheet();
          // Add worksheets
            Worksheet worksheet1 = document.Workbook.Worksheets.Add("Demo worksheet 1");
            Worksheet worksheet2 = document.Workbook.Worksheets.Add("Demo worksheet 2");
          // Get worksheet by name
            Worksheet worksheetByName = document.Workbook.Worksheets.ByName("Demo worksheet 2");
          // Set cell values
            worksheet1.Cell(0, 0).Value = "This is Demo worksheet 1";
            worksheetByName.Cell(0, 0).Value = "This is Demo worksheet 2";
            // Save document
            document.SaveAs("Worksheets.xls");
        }
    }
