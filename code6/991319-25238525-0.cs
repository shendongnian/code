    OleDbConnectionStringBuilder connectionStringBuilder = new OleDbConnectionStringBuilder();
    connectionStringBuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
    connectionStringBuilder.DataSource = excelPath; // This is your Excel File Full Path
    connectionStringBuilder.Add("Mode", "Read");
    const string extendedProperties = "Excel 12.0;IMEX=1;HDR=YES";
    connectionStringBuilder.Add("Extended Properties", extendedProperties);
    String connectionString = connectionStringBuilder.ToString();
    // Create connection object by using the preceding connection string.
    using (var objConn = new OleDbConnection(connectionString))
    {
         // Open connection with the database.
          objConn.Open();
       // Do operations with your File here
    }
