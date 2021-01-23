    public string DataTableToJsonWithJavaScriptSerializer(DataTable objDataTable)
    {
     JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
     List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
     Dictionary<string, object> childRow;
     foreach (DataRow row in objDataTable.Rows)
     {
     childRow = new Dictionary<string, object>();
     foreach (DataColumn col in table.Columns)
     {
     childRow.Add(col.ColumnName, row[col]);
     }
     parentRow.Add(childRow);
     }
     return jsSerializer.Serialize(parentRow);
    }
