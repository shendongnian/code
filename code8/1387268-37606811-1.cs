    private IDataReader OpenReader()
    {
        _strConn = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR={1};IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"",
                                    _fileName, Configuration.HasHeaders ? "Yes" : "No");
        conn = new OleDbConnection(_strConn);
        conn.Open();
        var schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
        string sheet = schemaTable.Rows[0]["TABLE_NAME"].ToString();
        var schemaTableColumns = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, sheet, null });
        // I am taking 1-st sheet here for simplicity
        string sheetName = schemaTable
          .Rows[0]["TABLE_NAME"].ToString();
        
        var cmd = new OleDbCommand(String.Format("SELECT * FROM [{0}]", sheetName), conn);
        cmd.CommandType = CommandType.Text;
        
        return cmd
           .ExecuteReader(CommandBehavior.Default);
    }
