    using ClosedXML.Excel;
    using System;
    using System.Data;
    
    namespace ClosedXML_Test
    {
    class Program
    {
        /// <summary>
        /// This example method generates a DataTable.
        /// </summary>
        static DataTable GetTable()
        {
            DataTable table = new DataTable("Test");//DataTable with name - works fine
            //DataTable table = new DataTable("Test"); //DataTable without name - issue reproduced as you mentioned
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            // Here we add five DataRows.
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
            return table;
        }
        static void Main(string[] args)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(GetTable());
            workbook.SaveAs("Sample.xlsx");
            workbook.Dispose();
            System.Diagnostics.Process.Start("Sample.xlsx");
        }
    }
    }
