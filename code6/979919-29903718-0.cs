    DataTable excelSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    string sheetName = null;
    for (int i = 0; i < dtExcelSchema.Rows.Count; i++)
    {
        string tableNameOnRow = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();
        if (!tableNameOnRow.Contains("FilterDatabase"))
        {
           sheetName = tableNameOnRow; 
           break;
        }
     }
     OleDbDataAdapter da = new OleDbDataAdapter();
     DataSet ds = new DataSet(); cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
