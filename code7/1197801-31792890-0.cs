    System.Data.OleDb.OleDbConnection MyConnection;
    System.Data.DataTable DtSet;
    System.Data.OleDb.OleDbDataAdapter MyCommand;
    MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='c:\\csharp.net-informations.xls';Extended Properties=Excel 8.0;");
    MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
    MyCommand.TableMappings.Add("Table", "TestTable");
    DtSet = new System.Data.DataTable();
    MyCommand.Fill(DtSet);
    MyConnection.Close();
