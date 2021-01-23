    StringBuilder strData = new StringBuilder();
    ReferenceDocument.SaveCopyAs(strSomeTempFile);
    var cnnStr = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended properties=\"Excel 8.0;IMEX=1;HDR=NO\"", strSomeTempFile);
    var cnn = new OleDbConnection(cnnStr);
    try
    {
        cnn.Open();
        var schemaTable = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        foreach(DataRow schemaRow in schemaTable.Rows)
        {
            string worksheetName = schemaRow["table_name"].ToString().Replace("'", "");
            string sql = String.Format("select * from [{0}]", worksheetName);
            var da = new OleDbDataAdapter(sql, cnn);
            var dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            foreach (DataColumn col in dt.Columns)
            {
                var value = row[col.ColumnName];
                if (!(value is System.DBNull)) strData.AppendLine(value.ToString());
            }
        }
    }
    catch (Exception e)
    {
        // handle error
        throw;
    }
    finally
    {
        cnn.Close();
    }
    return strData;
