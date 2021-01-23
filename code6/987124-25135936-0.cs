    var DBC = @"C:\mydata.dbc";
    string ConnectionString = string.Format("Provider=VFPOLEDB.1;Data Source={0};Exclusive=false;Ansi=true;OLE DB Services = 0", DBC);
    using (OleDbConnection testConnection = new OleDbConnection(ConnectionString))
    {
        OleDbCommand updateCommand = new OleDbCommand(@"update mytable set mymemo=alltrim(mymemo)+ttoc(datetime()) where thisfield='THISVALUE'", testConnection);
        testConnection.Open();
        updateCommand.ExecuteNonQuery();
        Console.WriteLine(@"Finished - press ENTER.");
        Console.ReadLine();
    }
