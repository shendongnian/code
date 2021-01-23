        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in ds.Tables[0].Columns)
            {
                row.Add(col.ColumnName.Trim(), dr[col]);
            }
            rows.Add(row);
        }
        return  JsonConvert.SerializeObject(rows);
