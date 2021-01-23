      DataTable dt11 = ds1.Tables[0];
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row;
        foreach (DataRow dr in dt11.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt11.Columns)
            {
               row.Add(col.ColumnName, dr[col]);
           }
            rows.Add(row);
        }
        return serializer.Serialize(rows);
