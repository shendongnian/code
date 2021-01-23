    DataTable dt = new DataTable();    
    sqlDa.Fill(dt);
            if (dt.Rows.Count > 0)
            { 
                StringBuilder html = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    html.Append(row.Field<Int32>("Columname"));
                
                }
            }
