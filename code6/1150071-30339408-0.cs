     public static string GetGroupModFunc(string group_mod_id)
        {
            var sconnect = ((SqlConnection)db.Database.Connection);
            sconnect.Open();
            SqlCommand cmd = new SqlCommand("GET_GROUP_PERMIT", sconnect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GID", group_mod_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            sconnect.Close();
       //It's flexible , because it's return DataTable , not entity , You can use avery where 
       // ok the result bind to datatable .I'll convert them to JSON
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return JsonConvert.SerializeObject(rows);    
        }
