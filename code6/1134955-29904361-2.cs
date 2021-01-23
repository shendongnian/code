    string excelFileSpec = @"C:\Users\Gord\Desktop\Book1.xlsx";
    string excelConnStr =
            "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + excelFileSpec + ";" +
            "Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";
    using (var excelCon = new OleDbConnection(excelConnStr))
    {
        using (var excelDA = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", excelCon))
        {
            var total = new DataTable();
            excelDA.Fill(total);
            Console.WriteLine("DataAdapter.fill() put {0} row(s) into \"total\":", total.Rows.Count);
            int i = 0;
            foreach (DataRow r in total.Rows)
            {
                Console.WriteLine("    total row[{0}]: RowState is \"{1}\"", i++, r.RowState);
            }
            DataTable dtMain = total.Clone();
            dtMain.Merge(total);
            Console.WriteLine("dtMain.Merge(total); completed. \"dtMain\" contains {0} row(s):", dtMain.Rows.Count);
            i = 0;
            foreach (DataRow r in dtMain.Rows)
            {
                Console.WriteLine("    dtMain row[{0}]: RowState is \"{1}\"", i++, r.RowState);
            }
        }
    }
    
