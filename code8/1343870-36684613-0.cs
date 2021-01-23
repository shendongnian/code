DataTable dataTable = blproperty.PropertyAll();
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();  
        List < Dictionary < string, object >> parentRow = new List < Dictionary < string, object >> ();  
        Dictionary < string, object > childRow;  
        foreach(DataRow row in dataTable.Rows) 
        {  
            childRow = new Dictionary < string, object > ();  
            foreach(DataColumn col in dataTable.Columns) 
            {  
                childRow.Add(col.ColumnName, row[col]);  
            }  
            parentRow.Add(childRow);  
        }  
        context.Response.Write(jsSerializer.Serialize(parentRow));
