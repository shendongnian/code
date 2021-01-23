    OleDb.OleDbConnectionStringBuilder Builder = new OleDb.OleDbConnectionStringBuilder();
    Builder.DataSource = "test.xlsx";
    Builder.Provider = "Microsoft.ACE.OLEDB.12.0";
    Builder.Add("Extended Properties", "Excel 12.0;HDR=Yes;IMEX=1");
    Console.WriteLine(Builder.ConnectionString);
