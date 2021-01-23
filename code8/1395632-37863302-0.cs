    // This translates to: AppFolder\Databases\Database1.accdb
    // AppFolder: Location of the executable
    // DataBases: an existing folder below AppFolder
    var databasePathName = Path.Combine(Application.StartupPath,"Databases", "Database1.accdb");
    var Builder = new OleDbConnectionStringBuilder()
        {
            Provider = "Microsoft.ACE.OLEDB.12.0",
            DataSource = databasePathName
        };
    using (OleDbConnection cn = new OleDbConnection() { ConnectionString = Builder.ConnectionString })
    {
        cn.Open();
        // do work
    }
